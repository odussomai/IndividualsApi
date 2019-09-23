using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualsApi.Migrations
{
    public partial class seed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Individuals",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "Image", "LastName", "PersonalId", "Sex", "City_Name" },
                values: new object[] { 2, new DateTime(1991, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Another", "", "Person", "11111111111", 1, "Kutaisi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Individuals",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
