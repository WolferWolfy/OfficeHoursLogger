using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using OfficeHoursServer.Settings;
using Microsoft.Extensions.OptionsModel;
using Microsoft.AspNet.Authentication.JwtBearer;
using System.Security.Claims;
using OfficeHoursServer.Models;
using Microsoft.Data.Entity;

namespace OfficeHoursServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment app)
        {
            this.Configuration = new ConfigurationBuilder()
                .SetBasePath(app.ApplicationBasePath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Auth0Settings>(Configuration.GetSection("Auth0"));

            services.AddMvc();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<OfficeHoursContext>(options =>
                {
                    options.UseSqlServer(Configuration["Data:ConnectionString"]);
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            loggerfactory.AddConsole();

            var logger = loggerfactory.CreateLogger("Auth0");
            var settings = app.ApplicationServices.GetService<IOptions<Auth0Settings>>();

            app.UseJwtBearerAuthentication(options =>
            {
                options.Audience = settings.Value.ClientId;
                options.Authority = $"https://{settings.Value.Domain}";
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        logger.LogError("Authentication failed.", context.Exception);
                        return Task.FromResult(0);
                    },
                    OnValidatedToken = context =>
                    {
                        var claimsIdentity = context.AuthenticationTicket.Principal.Identity as ClaimsIdentity;
                        claimsIdentity.AddClaim(new Claim("id_token",
                            context.Request.Headers["Authorization"][0].Substring(context.AuthenticationTicket.AuthenticationScheme.Length + 1)));

                            // OPTIONAL: you can read/modify the claims that are populated based on the JWT
                            // claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, claimsIdentity.FindFirst("name").Value));
                            return Task.FromResult(0);
                    }
                };
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
