using Microsoft.EntityFrameworkCore.Migrations;

namespace PieShop.Migrations
{
    public partial class SeparateUserCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ReturnUrl",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customer",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReturnUrl",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Customer",
                nullable: false,
                defaultValue: "");
        }
    }
}
