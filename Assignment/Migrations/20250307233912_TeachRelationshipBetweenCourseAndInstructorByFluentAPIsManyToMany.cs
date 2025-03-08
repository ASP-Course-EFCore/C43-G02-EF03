using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class TeachRelationshipBetweenCourseAndInstructorByFluentAPIsManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course_Inst",
                columns: table => new
                {
                    Inst_Id = table.Column<int>(type: "int", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    Evaluate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Inst", x => new { x.Inst_Id, x.Course_Id });
                    table.ForeignKey(
                        name: "FK_Course_Inst_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Course_Inst_Instructors_Inst_Id",
                        column: x => x.Inst_Id,
                        principalTable: "Instructors",
                        principalColumn: "InstructorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_Inst_Course_Id",
                table: "Course_Inst",
                column: "Course_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course_Inst");
        }
    }
}
