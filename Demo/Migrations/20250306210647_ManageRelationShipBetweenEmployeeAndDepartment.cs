using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class ManageRelationShipBetweenEmployeeAndDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeptManagerId",
                schema: "Sales",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DeptManagerId",
                schema: "Sales",
                table: "Departments",
                column: "DeptManagerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_DeptManagerId",
                schema: "Sales",
                table: "Departments",
                column: "DeptManagerId",
                principalTable: "Employees",
                principalColumn: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_DeptManagerId",
                schema: "Sales",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DeptManagerId",
                schema: "Sales",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DeptManagerId",
                schema: "Sales",
                table: "Departments");
        }
    }
}
