using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class LocateRelationshipBetweenInstructorAndDepartmentByFluentAPIs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocatedDepartmentId",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_LocatedDepartmentId",
                table: "Instructors",
                column: "LocatedDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_LocatedDepartmentId",
                table: "Instructors",
                column: "LocatedDepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_LocatedDepartmentId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_LocatedDepartmentId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "LocatedDepartmentId",
                table: "Instructors");
        }
    }
}
