using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualsApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Individuals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 150, nullable: false),
                    LastName = table.Column<string>(maxLength: 150, nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    PersonalId = table.Column<string>(maxLength: 11, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CityId = table.Column<int>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individuals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Individuals_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    IndividualId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    IndividualId = table.Column<int>(nullable: false),
                    RelativeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relations_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relations_Individuals_RelativeId",
                        column: x => x.RelativeId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Tbilisi" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Kutaisi" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Batumi" });

            migrationBuilder.InsertData(
                table: "Individuals",
                columns: new[] { "Id", "CityId", "DateOfBirth", "FirstName", "Image", "LastName", "PersonalId", "Sex" },
                values: new object[] { 1, 1, new DateTime(1991, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aleksandre", "", "Tsereteli", "01024080411", 0 });

            migrationBuilder.InsertData(
                table: "Individuals",
                columns: new[] { "Id", "CityId", "DateOfBirth", "FirstName", "Image", "LastName", "PersonalId", "Sex" },
                values: new object[] { 2, 2, new DateTime(1991, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Another", "", "Person", "11111111111", 1 });

            migrationBuilder.InsertData(
                table: "Individuals",
                columns: new[] { "Id", "CityId", "DateOfBirth", "FirstName", "Image", "LastName", "PersonalId", "Sex" },
                values: new object[] { 3, 3, new DateTime(1991, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Still", "", "Another", "11111111111", 0 });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "IndividualId", "PhoneNumber", "Type" },
                values: new object[] { 1, 1, "598499901", 1 });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "IndividualId", "PhoneNumber", "Type" },
                values: new object[] { 2, 1, "577676767", 2 });

            migrationBuilder.InsertData(
                table: "Relations",
                columns: new[] { "Id", "IndividualId", "RelativeId", "Type" },
                values: new object[] { 1, 1, 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Individuals_CityId",
                table: "Individuals",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_IndividualId",
                table: "Phones",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_RelativeId",
                table: "Relations",
                column: "RelativeId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_IndividualId_RelativeId_Type",
                table: "Relations",
                columns: new[] { "IndividualId", "RelativeId", "Type" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "Individuals");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
