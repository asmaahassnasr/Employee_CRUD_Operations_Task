using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD_APIs.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar (50)", maxLength: 50, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar (2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar (50)", maxLength: 50, nullable: false),
                    EmpTitle = table.Column<string>(type: "nvarchar (50)", maxLength: 50, nullable: false),
                    EmpEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmpPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EmpSalary = table.Column<double>(nullable: false),
                    EmpBirthDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_Employees_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CountryId",
                table: "Employees",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
