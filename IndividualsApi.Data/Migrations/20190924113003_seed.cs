using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualsApi.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Individuals_IndividualId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Individuals_RelativeId",
                table: "Relations");

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Individuals_IndividualId",
                table: "Relations",
                column: "IndividualId",
                principalTable: "Individuals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Individuals_RelativeId",
                table: "Relations",
                column: "RelativeId",
                principalTable: "Individuals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Individuals_IndividualId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Individuals_RelativeId",
                table: "Relations");

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Individuals_IndividualId",
                table: "Relations",
                column: "IndividualId",
                principalTable: "Individuals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Individuals_RelativeId",
                table: "Relations",
                column: "RelativeId",
                principalTable: "Individuals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
