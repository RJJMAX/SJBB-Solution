using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SJBB.Migrations
{
    public partial class reevalutedclassforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Orders_OrderId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Miscellaneous_Orders_OrderId",
                table: "Miscellaneous");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderline_Books_BookId",
                table: "Orderline");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderline_Miscellaneous_MiscellaneousId",
                table: "Orderline");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderline_Pictures_PictureId",
                table: "Orderline");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderline_Statues_StatueId",
                table: "Orderline");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Orders_OrderId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Statues_Orders_OrderId",
                table: "Statues");

            migrationBuilder.DropIndex(
                name: "IX_Orderline_BookId",
                table: "Orderline");

            migrationBuilder.DropIndex(
                name: "IX_Orderline_MiscellaneousId",
                table: "Orderline");

            migrationBuilder.DropIndex(
                name: "IX_Orderline_PictureId",
                table: "Orderline");

            migrationBuilder.DropIndex(
                name: "IX_Orderline_StatueId",
                table: "Orderline");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Orderline");

            migrationBuilder.DropColumn(
                name: "MiscellaneousId",
                table: "Orderline");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Orderline");

            migrationBuilder.DropColumn(
                name: "StatueId",
                table: "Orderline");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Statues",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Statues_OrderId",
                table: "Statues",
                newName: "IX_Statues_VendorId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Pictures",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_OrderId",
                table: "Pictures",
                newName: "IX_Pictures_VendorId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Orders",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Miscellaneous",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Miscellaneous_OrderId",
                table: "Miscellaneous",
                newName: "IX_Miscellaneous_VendorId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Books",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_OrderId",
                table: "Books",
                newName: "IX_Books_VendorId");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Vendors",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Orderline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orderline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Employees",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false)
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    StatueId = table.Column<int>(type: "int", nullable: true),
                    PictureId = table.Column<int>(type: "int", nullable: true),
                    MiscellaneousId = table.Column<int>(type: "int", nullable: true),
                    ChildrenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Children_ChildrenId",
                        column: x => x.ChildrenId,
                        principalTable: "Children",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Miscellaneous_MiscellaneousId",
                        column: x => x.MiscellaneousId,
                        principalTable: "Miscellaneous",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Statues_StatueId",
                        column: x => x.StatueId,
                        principalTable: "Statues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderline_ProductId",
                table: "Orderline",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_VendorId",
                table: "Children",
                column: "VendorId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Vendors_VendorId",
                table: "Books",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Miscellaneous_Vendors_VendorId",
                table: "Miscellaneous",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderline_Products_ProductId",
                table: "Orderline",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Vendors_VendorId",
                table: "Pictures",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statues_Vendors_VendorId",
                table: "Statues",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Vendors_VendorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Miscellaneous_Vendors_VendorId",
                table: "Miscellaneous");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderline_Products_ProductId",
                table: "Orderline");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Vendors_VendorId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Statues_Vendors_VendorId",
                table: "Statues");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orderline_ProductId",
                table: "Orderline");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orderline");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orderline");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "Statues",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Statues_VendorId",
                table: "Statues",
                newName: "IX_Statues_OrderId");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "Pictures",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_VendorId",
                table: "Pictures",
                newName: "IX_Pictures_OrderId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "Miscellaneous",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Miscellaneous_VendorId",
                table: "Miscellaneous",
                newName: "IX_Miscellaneous_OrderId");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "Books",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_VendorId",
                table: "Books",
                newName: "IX_Books_OrderId");

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Vendors",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Orderline",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MiscellaneousId",
                table: "Orderline",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Orderline",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatueId",
                table: "Orderline",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orderline_BookId",
                table: "Orderline",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderline_MiscellaneousId",
                table: "Orderline",
                column: "MiscellaneousId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderline_PictureId",
                table: "Orderline",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderline_StatueId",
                table: "Orderline",
                column: "StatueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Orders_OrderId",
                table: "Books",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Miscellaneous_Orders_OrderId",
                table: "Miscellaneous",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderline_Books_BookId",
                table: "Orderline",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderline_Miscellaneous_MiscellaneousId",
                table: "Orderline",
                column: "MiscellaneousId",
                principalTable: "Miscellaneous",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderline_Pictures_PictureId",
                table: "Orderline",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderline_Statues_StatueId",
                table: "Orderline",
                column: "StatueId",
                principalTable: "Statues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Orders_OrderId",
                table: "Pictures",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statues_Orders_OrderId",
                table: "Statues",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
