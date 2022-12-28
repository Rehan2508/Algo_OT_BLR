using Microsoft.EntityFrameworkCore.Migrations;

namespace Algo.App.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityCodes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityName = table.Column<string>(nullable: true),
                    code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityCodes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SP_Routes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_from = table.Column<string>(nullable: true),
                    from_city_code = table.Column<int>(nullable: false),
                    city_to = table.Column<string>(nullable: true),
                    to_city_code = table.Column<int>(nullable: false),
                    distance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SP_Routes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityCodes");

            migrationBuilder.DropTable(
                name: "SP_Routes");

        }
    }
}
