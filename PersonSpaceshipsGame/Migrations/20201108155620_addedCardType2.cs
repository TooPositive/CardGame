using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonSpaceshipsGame.Migrations
{
    public partial class addedCardType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardType1",
                table: "SpaceshipCards");

            migrationBuilder.DropColumn(
                name: "CardType1",
                table: "PersonCards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardType1",
                table: "SpaceshipCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CardType1",
                table: "PersonCards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
