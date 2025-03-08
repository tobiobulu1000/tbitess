using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tbites_Restaurant.Migrations
{
    public partial class AddBasketSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    BasketID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.BasketID);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutCustomers",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    BasketID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutCustomers", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    StockID = table.Column<int>(type: "INTEGER", nullable: false),
                    BasketID = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => new { x.StockID, x.BasketID });
                    table.ForeignKey(
                        name: "FK_BasketItems_Baskets_BasketID",
                        column: x => x.BasketID,
                        principalTable: "Baskets",
                        principalColumn: "BasketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketID",
                table: "BasketItems",
                column: "BasketID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "CheckoutCustomers");

            migrationBuilder.DropTable(
                name: "Baskets");
        }
    }
}
