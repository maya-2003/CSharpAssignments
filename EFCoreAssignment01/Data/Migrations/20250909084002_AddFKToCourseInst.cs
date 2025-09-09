using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreAssignment01.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFKToCourseInst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Course_Insts_Inst_Id",
                table: "Course_Insts",
                column: "Inst_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Insts_Courses_Course_Id",
                table: "Course_Insts",
                column: "Course_Id",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Insts_Instructors_Inst_Id",
                table: "Course_Insts",
                column: "Inst_Id",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Insts_Courses_Course_Id",
                table: "Course_Insts");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Insts_Instructors_Inst_Id",
                table: "Course_Insts");

            migrationBuilder.DropIndex(
                name: "IX_Course_Insts_Inst_Id",
                table: "Course_Insts");
        }
    }
}
