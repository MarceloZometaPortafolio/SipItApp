using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SipItApp.API.Migrations
{
    public partial class Prebuiltdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "base",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_base", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "flavor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false),
                    issyrup = table.Column<bool>(nullable: false),
                    issugarfree = table.Column<bool>(nullable: false),
                    isfresh = table.Column<bool>(nullable: false),
                    ispuree = table.Column<bool>(nullable: false),
                    isenergy = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flavor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "size",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false),
                    volume = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_size", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sanpetefavorites",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false),
                    baseid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanpetefavorites", x => x.id);
                    table.ForeignKey(
                        name: "sanpetefavorites_baseid_fkey",
                        column: x => x.baseid,
                        principalTable: "base",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sanpetefavorites_flavor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sanpetefavorites_id = table.Column<int>(nullable: true),
                    flavor_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanpetefavorites_flavor", x => x.id);
                    table.ForeignKey(
                        name: "sanpetefavorites_flavor_flavor_id_fkey",
                        column: x => x.flavor_id,
                        principalTable: "flavor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "sanpetefavorites_flavor_sanpetefavorites_id_fkey",
                        column: x => x.sanpetefavorites_id,
                        principalTable: "sanpetefavorites",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "base_name_key",
                table: "base",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sanpetefavorites_baseid",
                table: "sanpetefavorites",
                column: "baseid");

            migrationBuilder.CreateIndex(
                name: "sanpetefavorites_name_key",
                table: "sanpetefavorites",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sanpetefavorites_flavor_flavor_id",
                table: "sanpetefavorites_flavor",
                column: "flavor_id");

            migrationBuilder.CreateIndex(
                name: "IX_sanpetefavorites_flavor_sanpetefavorites_id",
                table: "sanpetefavorites_flavor",
                column: "sanpetefavorites_id");

            migrationBuilder.CreateIndex(
                name: "size_name_key",
                table: "size",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "size_price_key",
                table: "size",
                column: "price",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "size_volume_key",
                table: "size",
                column: "volume",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sanpetefavorites_flavor");

            migrationBuilder.DropTable(
                name: "size");

            migrationBuilder.DropTable(
                name: "flavor");

            migrationBuilder.DropTable(
                name: "sanpetefavorites");

            migrationBuilder.DropTable(
                name: "base");
        }
    }
}
