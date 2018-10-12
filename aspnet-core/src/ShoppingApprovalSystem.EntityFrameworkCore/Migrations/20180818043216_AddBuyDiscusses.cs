using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingApprovalSystem.Migrations
{
    public partial class AddBuyDiscusses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyAuthor",
                table: "buyList");

            migrationBuilder.CreateTable(
                name: "buyListDiscusses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuyListId = table.Column<int>(nullable: false),
                    IsAgree = table.Column<bool>(nullable: false),
                    Discuss = table.Column<string>(maxLength: 30, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buyListDiscusses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "buyListDiscusses");

            migrationBuilder.AddColumn<string>(
                name: "BuyAuthor",
                table: "buyList",
                maxLength: 30,
                nullable: true);
        }
    }
}
