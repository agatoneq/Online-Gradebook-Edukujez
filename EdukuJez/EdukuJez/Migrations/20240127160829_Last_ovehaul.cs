using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EdukuJez.Migrations
{
    public partial class Last_ovehaul : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "GradeType",
                table: "Grades",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GradeFormulas",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFinalGrade",
                table: "Activities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachment_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SubjectId",
                table: "Activities",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_SubjectId",
                table: "Attachment",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Subjects_SubjectId",
                table: "Activities",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Subjects_SubjectId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SubjectId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "GradeType",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "GradeFormulas");

            migrationBuilder.DropColumn(
                name: "IsFinalGrade",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Activities");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsUserSender = table.Column<bool>(type: "bit", nullable: false),
                    MessageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_MessageId",
                table: "Posts",
                column: "MessageId");
        }
    }
}
