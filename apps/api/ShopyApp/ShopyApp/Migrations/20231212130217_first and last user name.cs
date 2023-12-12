using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShopyApp.Migrations
{
    /// <inheritdoc />
    public partial class firstandlastusername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:btree_gin", ",,")
                .Annotation("Npgsql:PostgresExtension:btree_gist", ",,")
                .Annotation("Npgsql:PostgresExtension:citext", ",,")
                .Annotation("Npgsql:PostgresExtension:cube", ",,")
                .Annotation("Npgsql:PostgresExtension:dblink", ",,")
                .Annotation("Npgsql:PostgresExtension:dict_int", ",,")
                .Annotation("Npgsql:PostgresExtension:dict_xsyn", ",,")
                .Annotation("Npgsql:PostgresExtension:earthdistance", ",,")
                .Annotation("Npgsql:PostgresExtension:fuzzystrmatch", ",,")
                .Annotation("Npgsql:PostgresExtension:hstore", ",,")
                .Annotation("Npgsql:PostgresExtension:intarray", ",,")
                .Annotation("Npgsql:PostgresExtension:ltree", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_stat_statements", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_trgm", ",,")
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,")
                .Annotation("Npgsql:PostgresExtension:pgrowlocks", ",,")
                .Annotation("Npgsql:PostgresExtension:pgstattuple", ",,")
                .Annotation("Npgsql:PostgresExtension:tablefunc", ",,")
                .Annotation("Npgsql:PostgresExtension:unaccent", ",,")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .Annotation("Npgsql:PostgresExtension:xml2", ",,");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password_hash = table.Column<string>(type: "character varying", nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cart_owner = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cart_pkey", x => x.cart_id);
                    table.ForeignKey(
                        name: "fk_user",
                        column: x => x.cart_owner,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    price = table.Column<int>(type: "integer", nullable: false),
                    image_url = table.Column<string>(type: "character varying", nullable: true),
                    owner_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("products_pkey", x => x.product_id);
                    table.ForeignKey(
                        name: "fk_user",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "cart_item",
                columns: table => new
                {
                    cart_item_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    parent_cart_id = table.Column<int>(type: "integer", nullable: true),
                    product_id = table.Column<int>(type: "integer", nullable: true),
                    product_amount = table.Column<int>(type: "integer", nullable: true),
                    total_price = table.Column<int>(type: "integer", nullable: true)
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
                });

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
