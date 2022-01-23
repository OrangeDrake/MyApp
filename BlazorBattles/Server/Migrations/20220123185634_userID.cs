using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorBattles.Server.Migrations
{
    public partial class userID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "GoalDays",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GoalDays");
        }
    }
}
