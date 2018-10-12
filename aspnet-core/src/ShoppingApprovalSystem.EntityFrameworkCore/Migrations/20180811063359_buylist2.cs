using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingApprovalSystem.Migrations
{
    public partial class buylist2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "buyList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuyName = table.Column<string>(maxLength: 30, nullable: true),
                    BuyPrice = table.Column<decimal>(nullable: false),
                    BuyUrl = table.Column<string>(maxLength: 50, nullable: true),
                    BuyTypeName = table.Column<string>(maxLength: 30, nullable: true),
                    BuyLevel = table.Column<string>(maxLength: 30, nullable: true),
                    BuyCheckPerson = table.Column<string>(maxLength: 90, nullable: true),
                    BuyTime = table.Column<string>(maxLength: 30, nullable: true),
                    BuyAuthor = table.Column<string>(maxLength: 30, nullable: true),
                    BuyState = table.Column<int>(nullable: false),
                    BuyDesc = table.Column<string>(maxLength: 90, nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    Create = table.Column<DateTime>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buyList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "buyList");
        }
    }
}
