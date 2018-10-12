using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingApprovalSystem.Migrations
{
    public partial class AddBuyDiscusses2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyCheckPerson",
                table: "buyList");

            migrationBuilder.AddColumn<string>(
                name: "BuyAuthor",
                table: "buyList",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyAuthor",
                table: "buyList");

            migrationBuilder.AddColumn<string>(
                name: "BuyCheckPerson",
                table: "buyList",
                maxLength: 90,
                nullable: true);
        }
    }
}
