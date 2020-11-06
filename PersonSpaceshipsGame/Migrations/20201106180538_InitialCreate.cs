using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonSpaceshipsGame.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Mass = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpaceshipCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CrewCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceshipCards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonCards");

            migrationBuilder.DropTable(
                name: "SpaceshipCards");
        }
    }
}
