using Microsoft.EntityFrameworkCore.Migrations;

namespace EdukuJez.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassUsers_Classes_ClassCId",
                table: "ClassUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassUsers_Groups_GroupId",
                table: "ClassUsers");

            migrationBuilder.DropIndex(
                name: "IX_ClassUsers_ClassCId",
                table: "ClassUsers");

            migrationBuilder.DropIndex(
                name: "IX_ClassUsers_GroupId",
                table: "ClassUsers");

            migrationBuilder.DropColumn(
                name: "ClassCId",
                table: "ClassUsers");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "ClassUsers");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "ClassUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassUsers_ClassId",
                table: "ClassUsers",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassUsers_Classes_ClassId",
                table: "ClassUsers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassUsers_Classes_ClassId",
                table: "ClassUsers");

            migrationBuilder.DropIndex(
                name: "IX_ClassUsers_ClassId",
                table: "ClassUsers");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "ClassUsers");

            migrationBuilder.AddColumn<int>(
                name: "ClassCId",
                table: "ClassUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "ClassUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassUsers_ClassCId",
                table: "ClassUsers",
                column: "ClassCId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassUsers_GroupId",
                table: "ClassUsers",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassUsers_Classes_ClassCId",
                table: "ClassUsers",
                column: "ClassCId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassUsers_Groups_GroupId",
                table: "ClassUsers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
