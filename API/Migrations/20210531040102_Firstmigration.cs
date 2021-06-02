using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Person",
                columns: table => new
                {
                    NIK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salary = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Person", x => x.NIK);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_University",
                columns: table => new
                {
                    Universityid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_University", x => x.Universityid);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_Account",
                columns: table => new
                {
                    NIK = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_Account", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_T_Account_TB_M_Person_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_M_Person",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_Education",
                columns: table => new
                {
                    Educationid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Universityid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_Education", x => x.Educationid);
                    table.ForeignKey(
                        name: "FK_TB_T_Education_TB_T_University_Universityid",
                        column: x => x.Universityid,
                        principalTable: "TB_T_University",
                        principalColumn: "Universityid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_Profiling",
                columns: table => new
                {
                    NIK = table.Column<int>(type: "int", nullable: false),
                    Educationid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_Profiling", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_T_Profiling_TB_T_Account_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_T_Account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_T_Profiling_TB_T_Education_Educationid",
                        column: x => x.Educationid,
                        principalTable: "TB_T_Education",
                        principalColumn: "Educationid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Education_Universityid",
                table: "TB_T_Education",
                column: "Universityid");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Profiling_Educationid",
                table: "TB_T_Profiling",
                column: "Educationid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_T_Profiling");

            migrationBuilder.DropTable(
                name: "TB_T_Account");

            migrationBuilder.DropTable(
                name: "TB_T_Education");

            migrationBuilder.DropTable(
                name: "TB_M_Person");

            migrationBuilder.DropTable(
                name: "TB_T_University");
        }
    }
}
