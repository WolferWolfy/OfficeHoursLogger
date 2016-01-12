using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using OfficeHoursServer.Models;

namespace OfficeHoursServer.Migrations
{
    [DbContext(typeof(OfficeHoursContext))]
    [Migration("20160112153515_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OfficeHoursServer.Models.DayLog", b =>
                {
                    b.Property<int>("DayLogId")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan>("Arrive");

                    b.Property<DateTime>("Day");

                    b.Property<TimeSpan>("InOffice");

                    b.Property<TimeSpan>("Leave");

                    b.Property<int>("MonthLogId");

                    b.Property<TimeSpan>("OutOfOffice");

                    b.HasKey("DayLogId");
                });

            modelBuilder.Entity("OfficeHoursServer.Models.LogEntry", b =>
                {
                    b.Property<int>("LogEntryId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DayLogId");

                    b.Property<int>("Direction");

                    b.Property<string>("Name");

                    b.Property<TimeSpan>("Time");

                    b.HasKey("LogEntryId");
                });

            modelBuilder.Entity("OfficeHoursServer.Models.MonthLog", b =>
                {
                    b.Property<int>("MonthLogId")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan>("AverageIn");

                    b.Property<TimeSpan>("AverageOut");

                    b.Property<int>("UserId");

                    b.HasKey("MonthLogId");
                });

            modelBuilder.Entity("OfficeHoursServer.Models.OfficeUser", b =>
                {
                    b.Property<int>("OfficeUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.HasKey("OfficeUserId");
                });

            modelBuilder.Entity("OfficeHoursServer.Models.DayLog", b =>
                {
                    b.HasOne("OfficeHoursServer.Models.MonthLog")
                        .WithMany()
                        .HasForeignKey("MonthLogId");
                });

            modelBuilder.Entity("OfficeHoursServer.Models.LogEntry", b =>
                {
                    b.HasOne("OfficeHoursServer.Models.DayLog")
                        .WithMany()
                        .HasForeignKey("DayLogId");
                });

            modelBuilder.Entity("OfficeHoursServer.Models.MonthLog", b =>
                {
                    b.HasOne("OfficeHoursServer.Models.OfficeUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
