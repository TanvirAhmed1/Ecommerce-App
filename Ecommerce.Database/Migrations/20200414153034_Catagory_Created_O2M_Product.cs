using Microsoft.EntityFrameworkCore.Migrations;

namespace NewEcommerce.Migrations
{
    public partial class Catagory_Created_O2M_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CatagoryId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Catagories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catagories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatagoryId",
                table: "Products",
                column: "CatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Catagories_CatagoryId",
                table: "Products",
                column: "CatagoryId",
                principalTable: "Catagories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Catagories_CatagoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Catagories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CatagoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatagoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
