using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    personID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    tel = table.Column<string>(maxLength: 50, nullable: true),
                    department = table.Column<string>(maxLength: 50, nullable: true),
                    lname = table.Column<string>(maxLength: 50, nullable: true),
                    location = table.Column<IGeometry>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.personID);
                });

            migrationBuilder.CreateTable(
                name: "places",
                columns: table => new
                {
                    placesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(maxLength: 50, nullable: true),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    pic_1_url = table.Column<string>(maxLength: 500, nullable: true),
                    pic_2_url = table.Column<string>(maxLength: 500, nullable: true),
                    tel = table.Column<string>(maxLength: 50, nullable: true),
                    url = table.Column<string>(maxLength: 50, nullable: true),
                    address = table.Column<string>(maxLength: 50, nullable: true),
                    location = table.Column<IGeometry>(nullable: true),
                    geotype = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_places", x => x.placesID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "places");
        }
    }
}
