using Microsoft.EntityFrameworkCore.Migrations;

namespace EdukuJez.Migrations
{
    public partial class Activity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Grades",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_ActivityId",
                table: "Grades",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Activities_ActivityId",
                table: "Grades",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Activities_ActivityId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_ActivityId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Grades");
        }
    }
}
