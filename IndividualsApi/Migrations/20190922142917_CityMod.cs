using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualsApi.Migrations
{
    public partial class CityMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Individuals_Cities_CityId",
                table: "Individuals");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Individuals",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Individuals_Cities_CityId",
                table: "Individuals",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Individuals_Cities_CityId",
                table: "Individuals");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Individuals",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Individuals_Cities_CityId",
                table: "Individuals",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
