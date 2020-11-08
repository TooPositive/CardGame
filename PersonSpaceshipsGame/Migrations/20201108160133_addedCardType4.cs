using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonSpaceshipsGame.Migrations
{
    public partial class addedCardType4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonCards_Players_PlayerId",
                table: "PersonCards");

            migrationBuilder.DropForeignKey(
                name: "FK_SpaceshipCards_Players_PlayerId",
                table: "SpaceshipCards");

            migrationBuilder.DropIndex(
                name: "IX_SpaceshipCards_PlayerId",
                table: "SpaceshipCards");

            migrationBuilder.DropIndex(
                name: "IX_PersonCards_PlayerId",
                table: "PersonCards");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "SpaceshipCards");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "PersonCards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "SpaceshipCards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "PersonCards",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
