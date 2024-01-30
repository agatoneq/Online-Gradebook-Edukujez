using Microsoft.EntityFrameworkCore.Migrations;

namespace EdukuJez.Migrations
{
    public partial class last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "GradeFormulas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GradeFormulas_SubjectId",
                table: "GradeFormulas",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_GradeFormulas_Subjects_SubjectId",
                table: "GradeFormulas",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradeFormulas_Subjects_SubjectId",
                table: "GradeFormulas");

            migrationBuilder.DropIndex(
                name: "IX_GradeFormulas_SubjectId",
                table: "GradeFormulas");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "GradeFormulas");
        }
    }
}
