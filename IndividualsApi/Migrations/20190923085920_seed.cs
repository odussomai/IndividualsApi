using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualsApi.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Individuals_Cities_CityId",
                table: "Individuals");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Individuals_CityId",
                table: "Individuals");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Individuals");

            migrationBuilder.AddColumn<string>(
                name: "City_Name",
                table: "Individuals",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Individuals",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "Image", "LastName", "PersonalId", "Sex", "City_Name" },
                values: new object[] { 1, new DateTime(1991, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aleksandre", "", "Tsereteli", "01024080411", 0, "Tbilisi" });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "IndividualId", "PhoneNumber", "Type" },
                values: new object[] { 1, 1, "598499901", 1 });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "IndividualId", "PhoneNumber", "Type" },
                values: new object[] { 2, 1, "577676767", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Individuals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "City_Name",
                table: "Individuals");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Individuals",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Individuals_CityId",
                table: "Individuals",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Individuals_Cities_CityId",
                table: "Individuals",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
