using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EdukuJez.Migrations
{
    public partial class GradeFormula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradeFormulas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Formula = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeFormulas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    UserSurname = table.Column<string>(nullable: false),
                    UserLogin = table.Column<string>(nullable: false),
                    UserPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_GradeFormulas_Id",
                        column: x => x.Id,
                        principalTable: "GradeFormulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ParentGroupId = table.Column<int>(nullable: true),
                    EducatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Users_EducatorId",
                        column: x => x.EducatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Groups_Groups_ParentGroupId",
                        column: x => x.ParentGroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    IsGroupMsg = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Remarks",
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
                    table.PrimaryKey("PK_Remarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Remarks_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Remarks_Users_SubmitterId",
                        column: x => x.SubmitterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupUsers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(nullable: false),
                    SubjectDesc = table.Column<string>(nullable: false),
                    TeacherGroupId = table.Column<int>(nullable: false),
                    StudentGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Groups_StudentGroupId",
                        column: x => x.StudentGroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_Groups_TeacherGroupId",
                        column: x => x.TeacherGroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MessageGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(nullable: true),
                    GroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageGroups_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MessageUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageUsers_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    MessageId = table.Column<int>(nullable: true),
                    IsUserSender = table.Column<bool>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(nullable: true),
                    GroupId = table.Column<int>(nullable: true),
                    WardenId = table.Column<int>(nullable: true),
                    Class = table.Column<int>(nullable: false),
                    Hour = table.Column<string>(nullable: true),
                    Day = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classes_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classes_Users_WardenId",
                        column: x => x.WardenId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeValue = table.Column<int>(nullable: false),
                    GradeWeight = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: true),
                    ActivityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassUsers_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_GroupId",
                table: "Classes",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SubjectId",
                table: "Classes",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_WardenId",
                table: "Classes",
                column: "WardenId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassUsers_ClassId",
                table: "ClassUsers",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassUsers_UserId",
                table: "ClassUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_ActivityId",
                table: "Grades",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectId",
                table: "Grades",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_TeacherId",
                table: "Grades",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_EducatorId",
                table: "Groups",
                column: "EducatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ParentGroupId",
                table: "Groups",
                column: "ParentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_GroupId",
                table: "GroupUsers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_UserId",
                table: "GroupUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageGroups_GroupId",
                table: "MessageGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageGroups_MessageId",
                table: "MessageGroups",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageUsers_MessageId",
                table: "MessageUsers",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageUsers_UserId",
                table: "MessageUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_MessageId",
                table: "Posts",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Remarks_StudentId",
                table: "Remarks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Remarks_SubmitterId",
                table: "Remarks",
                column: "SubmitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_StudentGroupId",
                table: "Subjects",
                column: "StudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectName",
                table: "Subjects",
                column: "SubjectName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherGroupId",
                table: "Subjects",
                column: "TeacherGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserLogin",
                table: "Users",
                column: "UserLogin",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calendar");

            migrationBuilder.DropTable(
                name: "ClassUsers");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "GroupUsers");

            migrationBuilder.DropTable(
                name: "MessageGroups");

            migrationBuilder.DropTable(
                name: "MessageUsers");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Remarks");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "GradeFormulas");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
