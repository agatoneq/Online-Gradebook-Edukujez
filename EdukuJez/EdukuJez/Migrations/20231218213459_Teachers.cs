using Microsoft.EntityFrameworkCore.Migrations;

namespace EdukuJez.Migrations
{
    public partial class Teachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "WardenId",
                table: "Classes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_WardenId",
                table: "Classes",
                column: "WardenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Users_WardenId",
                table: "Classes",
                column: "WardenId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Users_WardenId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_WardenId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "WardenId",
                table: "Classes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
