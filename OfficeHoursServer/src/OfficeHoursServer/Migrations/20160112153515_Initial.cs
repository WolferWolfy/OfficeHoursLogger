using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace OfficeHoursServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfficeUser",
                columns: table => new
                {
                    OfficeUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeUser", x => x.OfficeUserId);
                });
            migrationBuilder.CreateTable(
                name: "MonthLog",
                columns: table => new
                {
                    MonthLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AverageIn = table.Column<TimeSpan>(nullable: false),
                    AverageOut = table.Column<TimeSpan>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthLog", x => x.MonthLogId);
                    table.ForeignKey(
                        name: "FK_MonthLog_OfficeUser_UserId",
                        column: x => x.UserId,
                        principalTable: "OfficeUser",
                        principalColumn: "OfficeUserId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "DayLog",
                columns: table => new
                {
                    DayLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Arrive = table.Column<TimeSpan>(nullable: false),
                    Day = table.Column<DateTime>(nullable: false),
                    InOffice = table.Column<TimeSpan>(nullable: false),
                    Leave = table.Column<TimeSpan>(nullable: false),
                    MonthLogId = table.Column<int>(nullable: false),
                    OutOfOffice = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayLog", x => x.DayLogId);
                    table.ForeignKey(
                        name: "FK_DayLog_MonthLog_MonthLogId",
                        column: x => x.MonthLogId,
                        principalTable: "MonthLog",
                        principalColumn: "MonthLogId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "LogEntry",
                columns: table => new
                {
                    LogEntryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayLogId = table.Column<int>(nullable: false),
                    Direction = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Time = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntry", x => x.LogEntryId);
                    table.ForeignKey(
                        name: "FK_LogEntry_DayLog_DayLogId",
                        column: x => x.DayLogId,
                        principalTable: "DayLog",
                        principalColumn: "DayLogId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("LogEntry");
            migrationBuilder.DropTable("DayLog");
            migrationBuilder.DropTable("MonthLog");
            migrationBuilder.DropTable("OfficeUser");
        }
    }
}
