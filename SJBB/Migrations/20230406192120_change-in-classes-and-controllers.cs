using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SJBB.Migrations
{
    public partial class changeinclassesandcontrollers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Books_BookId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Children_ChildrenId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Miscellaneous_MiscellaneousId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Pictures_PictureId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Statues_StatueId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Miscellaneous");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Statues");

            migrationBuilder.DropIndex(
                name: "IX_Products_BookId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ChildrenId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MiscellaneousId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PictureId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StatueId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ChildrenId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MiscellaneousId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StatueId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryNumber",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "vendorId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_vendorId",
                table: "Products",
                column: "vendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Vendors_vendorId",
                table: "Products",
                column: "vendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Vendors_vendorId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_vendorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryNumber",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "vendorId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChildrenId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MiscellaneousId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatueId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    PrintYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(11,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Children_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Miscellaneous",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(11,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miscellaneous", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Miscellaneous_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(11,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statues_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BookId",
                table: "Products",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ChildrenId",
                table: "Products",
                column: "ChildrenId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MiscellaneousId",
                table: "Products",
                column: "MiscellaneousId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PictureId",
                table: "Products",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StatueId",
                table: "Products",
                column: "StatueId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_VendorId",
                table: "Books",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_VendorId",
                table: "Children",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Miscellaneous_VendorId",
                table: "Miscellaneous",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_VendorId",
                table: "Pictures",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Statues_VendorId",
                table: "Statues",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Books_BookId",
                table: "Products",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Children_ChildrenId",
                table: "Products",
                column: "ChildrenId",
                principalTable: "Children",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Miscellaneous_MiscellaneousId",
                table: "Products",
                column: "MiscellaneousId",
                principalTable: "Miscellaneous",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Pictures_PictureId",
                table: "Products",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Statues_StatueId",
                table: "Products",
                column: "StatueId",
                principalTable: "Statues",
                principalColumn: "Id");
        }
    }
}
