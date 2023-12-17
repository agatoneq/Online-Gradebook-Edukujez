using Microsoft.EntityFrameworkCore.Migrations;

namespace EdukuJez.Migrations
{
    public partial class SubjectDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubjectDesc",
                table: "Subjects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectDesc",
                table: "Subjects");
        }
    }
}
