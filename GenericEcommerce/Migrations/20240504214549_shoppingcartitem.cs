using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenericEcommerce.Migrations
{
    /// <inheritdoc />
    public partial class shoppingcartitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemsShoppingCart",
                columns: table => new
                {
                    ItemShoppingCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsShoppingCart", x => x.ItemShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ItemsShoppingCart_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsShoppingCart_GameId",
                table: "ItemsShoppingCart",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsShoppingCart");
        }
    }
}
