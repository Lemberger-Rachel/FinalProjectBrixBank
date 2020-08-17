using Microsoft.EntityFrameworkCore.Migrations;

namespace BrixBank.Data.Migrations
{
    public partial class FivMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoanSupplied",
                table: "LoanRequests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanSupplied",
                table: "LoanRequests");
        }
    }
}
