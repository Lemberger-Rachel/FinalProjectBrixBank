using Microsoft.EntityFrameworkCore.Migrations;

namespace BrixBank.Data.Migrations
{
    public partial class SixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "LoanRequests");

            migrationBuilder.DropColumn(
                name: "GetCitizen",
                table: "LoanRequests");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "LoanRequests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "LoanRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GetCitizen",
                table: "LoanRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Salary",
                table: "LoanRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
