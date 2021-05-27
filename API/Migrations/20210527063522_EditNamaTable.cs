using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class EditNamaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Universities_Universityid",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Profilings_Educations_Educationid",
                table: "Profilings");

            migrationBuilder.DropForeignKey(
                name: "FK_Profilings_TB_M_Account_NIK",
                table: "Profilings");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Account_TB_M_Person_NIK",
                table: "TB_M_Account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Universities",
                table: "Universities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_M_Account",
                table: "TB_M_Account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profilings",
                table: "Profilings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.RenameTable(
                name: "Universities",
                newName: "TB_T_University");

            migrationBuilder.RenameTable(
                name: "TB_M_Account",
                newName: "TB_T_Account");

            migrationBuilder.RenameTable(
                name: "Profilings",
                newName: "TB_T_Profiling");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "TB_T_Education");

            migrationBuilder.RenameIndex(
                name: "IX_Profilings_Educationid",
                table: "TB_T_Profiling",
                newName: "IX_TB_T_Profiling_Educationid");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_Universityid",
                table: "TB_T_Education",
                newName: "IX_TB_T_Education_Universityid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_University",
                table: "TB_T_University",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_Account",
                table: "TB_T_Account",
                column: "NIK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_Profiling",
                table: "TB_T_Profiling",
                column: "NIK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_Education",
                table: "TB_T_Education",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Account_TB_M_Person_NIK",
                table: "TB_T_Account",
                column: "NIK",
                principalTable: "TB_M_Person",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Education_TB_T_University_Universityid",
                table: "TB_T_Education",
                column: "Universityid",
                principalTable: "TB_T_University",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Profiling_TB_T_Account_NIK",
                table: "TB_T_Profiling",
                column: "NIK",
                principalTable: "TB_T_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Profiling_TB_T_Education_Educationid",
                table: "TB_T_Profiling",
                column: "Educationid",
                principalTable: "TB_T_Education",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Account_TB_M_Person_NIK",
                table: "TB_T_Account");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Education_TB_T_University_Universityid",
                table: "TB_T_Education");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Profiling_TB_T_Account_NIK",
                table: "TB_T_Profiling");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Profiling_TB_T_Education_Educationid",
                table: "TB_T_Profiling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_University",
                table: "TB_T_University");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_Profiling",
                table: "TB_T_Profiling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_Education",
                table: "TB_T_Education");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_Account",
                table: "TB_T_Account");

            migrationBuilder.RenameTable(
                name: "TB_T_University",
                newName: "Universities");

            migrationBuilder.RenameTable(
                name: "TB_T_Profiling",
                newName: "Profilings");

            migrationBuilder.RenameTable(
                name: "TB_T_Education",
                newName: "Educations");

            migrationBuilder.RenameTable(
                name: "TB_T_Account",
                newName: "TB_M_Account");

            migrationBuilder.RenameIndex(
                name: "IX_TB_T_Profiling_Educationid",
                table: "Profilings",
                newName: "IX_Profilings_Educationid");

            migrationBuilder.RenameIndex(
                name: "IX_TB_T_Education_Universityid",
                table: "Educations",
                newName: "IX_Educations_Universityid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Universities",
                table: "Universities",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profilings",
                table: "Profilings",
                column: "NIK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_M_Account",
                table: "TB_M_Account",
                column: "NIK");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Universities_Universityid",
                table: "Educations",
                column: "Universityid",
                principalTable: "Universities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profilings_Educations_Educationid",
                table: "Profilings",
                column: "Educationid",
                principalTable: "Educations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profilings_TB_M_Account_NIK",
                table: "Profilings",
                column: "NIK",
                principalTable: "TB_M_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Account_TB_M_Person_NIK",
                table: "TB_M_Account",
                column: "NIK",
                principalTable: "TB_M_Person",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
