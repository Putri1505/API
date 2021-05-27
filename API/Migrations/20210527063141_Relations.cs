using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Education_id",
                table: "Profilings");

            migrationBuilder.DropColumn(
                name: "University_id",
                table: "Educations");

            migrationBuilder.AlterColumn<int>(
                name: "NIK",
                table: "Profilings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Educationid",
                table: "Profilings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Universityid",
                table: "Educations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profilings_Educationid",
                table: "Profilings",
                column: "Educationid");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_Universityid",
                table: "Educations",
                column: "Universityid");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Profilings_Educationid",
                table: "Profilings");

            migrationBuilder.DropIndex(
                name: "IX_Educations_Universityid",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "Educationid",
                table: "Profilings");

            migrationBuilder.DropColumn(
                name: "Universityid",
                table: "Educations");

            migrationBuilder.AlterColumn<int>(
                name: "NIK",
                table: "Profilings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Education_id",
                table: "Profilings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "University_id",
                table: "Educations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
