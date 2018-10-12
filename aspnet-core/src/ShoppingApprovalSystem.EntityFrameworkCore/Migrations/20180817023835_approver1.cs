using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingApprovalSystem.Migrations
{
    public partial class approver1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproval",
                table: "approvers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsApproval",
                table: "approvers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
