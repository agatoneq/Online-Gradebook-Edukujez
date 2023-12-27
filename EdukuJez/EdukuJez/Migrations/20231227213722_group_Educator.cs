using Microsoft.EntityFrameworkCore.Migrations;

namespace EdukuJez.Migrations
{
    public partial class group_Educator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducatorId",
                table: "Groups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_EducatorId",
                table: "Groups",
                column: "EducatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_EducatorId",
                table: "Groups",
                column: "EducatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_EducatorId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_EducatorId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "EducatorId",
                table: "Groups");
        }
    }
}
