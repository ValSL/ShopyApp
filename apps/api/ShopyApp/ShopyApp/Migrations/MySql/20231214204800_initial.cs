using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ShopyApp.Migrations.MySql
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    password_hash = table.Column<string>(type: "longtext", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.user_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    cart_owner = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cart_pkey", x => x.cart_id);
                    table.ForeignKey(
                        name: "fk_cart_owner",
                        column: x => x.cart_owner,
                        principalTable: "users",
                        principalColumn: "user_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    image_url = table.Column<string>(type: "longtext", nullable: true),
                    owner_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("products_pkey", x => x.product_id);
                    table.ForeignKey(
                        name: "fk_product_owner",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cart_item",
                columns: table => new
                {
                    cart_item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    parent_cart_id = table.Column<int>(type: "int", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    product_amount = table.Column<int>(type: "int", nullable: true),
                    total_price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cart_item_pkey", x => x.cart_item_id);
                    table.ForeignKey(
                        name: "fk_parent_cart",
                        column: x => x.parent_cart_id,
                        principalTable: "cart",
                        principalColumn: "cart_id");
                    table.ForeignKey(
                        name: "fk_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_cart_cart_owner",
                table: "cart",
                column: "cart_owner");

            migrationBuilder.CreateIndex(
                name: "IX_cart_item_parent_cart_id",
                table: "cart_item",
                column: "parent_cart_id");

            migrationBuilder.CreateIndex(
                name: "IX_cart_item_product_id",
                table: "cart_item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_owner_id",
                table: "products",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "users_email_key",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cart_item");

            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
