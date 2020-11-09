using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonSpaceshipsGame.Migrations
{
    public partial class addedCardType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardType1",
                table: "SpaceshipCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CardType",
                table: "SpaceshipCards",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "SpaceshipCards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CardType1",
                table: "PersonCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CardType",
                table: "PersonCards",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "PersonCards",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpaceshipCards_PlayerId",
                table: "SpaceshipCards",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonCards_PlayerId",
                table: "PersonCards",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonCards_Players_PlayerId",
                table: "PersonCards",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceshipCards_Players_PlayerId",
                table: "SpaceshipCards",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonCards_Players_PlayerId",
                table: "PersonCards");

            migrationBuilder.DropForeignKey(
                name: "FK_SpaceshipCards_Players_PlayerId",
                table: "SpaceshipCards");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropIndex(
                name: "IX_SpaceshipCards_PlayerId",
                table: "SpaceshipCards");

            migrationBuilder.DropIndex(
                name: "IX_PersonCards_PlayerId",
                table: "PersonCards");

            migrationBuilder.DropColumn(
                name: "CardType1",
                table: "SpaceshipCards");

            migrationBuilder.DropColumn(
                name: "CardType",
                table: "SpaceshipCards");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "SpaceshipCards");

            migrationBuilder.DropColumn(
                name: "CardType1",
                table: "PersonCards");

            migrationBuilder.DropColumn(
                name: "CardType",
                table: "PersonCards");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "PersonCards");
        }
    }
}
