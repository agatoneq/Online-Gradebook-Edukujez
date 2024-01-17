using Microsoft.EntityFrameworkCore.Migrations;

namespace EdukuJez.Migrations
{
    public partial class Remarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Remark",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    SubmitterId = table.Column<int>(nullable: false),
                    Contents = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Remark_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Remark_Users_SubmitterId",
                        column: x => x.SubmitterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Remark_StudentId",
                table: "Remark",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Remark_SubmitterId",
                table: "Remark",
                column: "SubmitterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Remark");
        }
    }
}
