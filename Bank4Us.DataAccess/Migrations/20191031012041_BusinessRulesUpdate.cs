using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank4Us.DataAccess.Migrations
{
    public partial class BusinessRulesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentificationNumber",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentificationNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Accounts");
        }
    }
}
