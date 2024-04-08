using Microsoft.EntityFrameworkCore.Migrations;

namespace EdukuJez.Migrations
{
    public partial class substitution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cyclicality",
                table: "Classes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubstitutionId",
                table: "Classes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Substitution",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc = table.Column<string>(nullable: true),
                    SubTeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Substitution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Substitution_Users_SubTeacherId",
                        column: x => x.SubTeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SubstitutionId",
                table: "Classes",
                column: "SubstitutionId",
                unique: true,
                filter: "[SubstitutionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Substitution_SubTeacherId",
                table: "Substitution",
                column: "SubTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Substitution_SubstitutionId",
                table: "Classes",
                column: "SubstitutionId",
                principalTable: "Substitution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Substitution_SubstitutionId",
                table: "Classes");

            migrationBuilder.DropTable(
                name: "Substitution");

            migrationBuilder.DropIndex(
                name: "IX_Classes_SubstitutionId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Cyclicality",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "SubstitutionId",
                table: "Classes");
        }
    }
}
