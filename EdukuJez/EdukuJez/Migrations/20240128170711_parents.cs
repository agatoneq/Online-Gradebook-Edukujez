using Microsoft.EntityFrameworkCore.Migrations;

namespace EdukuJez.Migrations
{
    public partial class parents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Remarks_Users_StudentId",
                table: "Remarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Remarks_Users_SubmitterId",
                table: "Remarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Remarks",
                table: "Remarks");

            migrationBuilder.RenameTable(
                name: "Remarks",
                newName: "Remark");

            migrationBuilder.RenameIndex(
                name: "IX_Remarks_SubmitterId",
                table: "Remark",
                newName: "IX_Remark_SubmitterId");

            migrationBuilder.RenameIndex(
                name: "IX_Remarks_StudentId",
                table: "Remark",
                newName: "IX_Remark_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Remark",
                table: "Remark",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserParents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserParents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserParents_Users_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserParents_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserParents_ParentId",
                table: "UserParents",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserParents_StudentId",
                table: "UserParents",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Remark_Users_StudentId",
                table: "Remark",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Remark_Users_SubmitterId",
                table: "Remark",
                column: "SubmitterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Remark_Users_StudentId",
                table: "Remark");

            migrationBuilder.DropForeignKey(
                name: "FK_Remark_Users_SubmitterId",
                table: "Remark");

            migrationBuilder.DropTable(
                name: "UserParents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Remark",
                table: "Remark");

            migrationBuilder.RenameTable(
                name: "Remark",
                newName: "Remarks");

            migrationBuilder.RenameIndex(
                name: "IX_Remark_SubmitterId",
                table: "Remarks",
                newName: "IX_Remarks_SubmitterId");

            migrationBuilder.RenameIndex(
                name: "IX_Remark_StudentId",
                table: "Remarks",
                newName: "IX_Remarks_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Remarks",
                table: "Remarks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Remarks_Users_StudentId",
                table: "Remarks",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Remarks_Users_SubmitterId",
                table: "Remarks",
                column: "SubmitterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
