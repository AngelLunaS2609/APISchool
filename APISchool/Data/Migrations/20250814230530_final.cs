using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISchool.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherStudents_Students_StudentsId",
                table: "TeacherStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherStudents_Teachers_TeachersId",
                table: "TeacherStudents");

            migrationBuilder.DropIndex(
                name: "IX_TeacherStudents_StudentsId",
                table: "TeacherStudents");

            migrationBuilder.DropIndex(
                name: "IX_TeacherStudents_TeachersId",
                table: "TeacherStudents");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "TeacherStudents");

            migrationBuilder.DropColumn(
                name: "TeachersId",
                table: "TeacherStudents");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudents_StudentId",
                table: "TeacherStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudents_TeacherId",
                table: "TeacherStudents",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherStudents_Students_StudentId",
                table: "TeacherStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherStudents_Teachers_TeacherId",
                table: "TeacherStudents",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherStudents_Students_StudentId",
                table: "TeacherStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherStudents_Teachers_TeacherId",
                table: "TeacherStudents");

            migrationBuilder.DropIndex(
                name: "IX_TeacherStudents_StudentId",
                table: "TeacherStudents");

            migrationBuilder.DropIndex(
                name: "IX_TeacherStudents_TeacherId",
                table: "TeacherStudents");

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "TeacherStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeachersId",
                table: "TeacherStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudents_StudentsId",
                table: "TeacherStudents",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudents_TeachersId",
                table: "TeacherStudents",
                column: "TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherStudents_Students_StudentsId",
                table: "TeacherStudents",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherStudents_Teachers_TeachersId",
                table: "TeacherStudents",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
