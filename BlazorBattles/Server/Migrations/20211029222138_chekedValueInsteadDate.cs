using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorBattles.Server.Migrations
{
    public partial class chekedValueInsteadDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckedDate",
                table: "GoalDays");

            migrationBuilder.AddColumn<int>(
                name: "CheckedValue",
                table: "GoalDays",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckedValue",
                table: "GoalDays");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckedDate",
                table: "GoalDays",
                type: "datetime2",
                nullable: true);
        }
    }
}
