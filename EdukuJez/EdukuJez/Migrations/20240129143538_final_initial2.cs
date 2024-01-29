using Microsoft.EntityFrameworkCore.Migrations;

namespace EdukuJez.Migrations
{
    public partial class final_initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_GradeFormulas_FormulaId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_FormulaId",
                table: "Activities");

            migrationBuilder.AlterColumn<int>(
                name: "FormulaId",
                table: "Activities",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_FormulaId",
                table: "Activities",
                column: "FormulaId",
                unique: true,
                filter: "[FormulaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_GradeFormulas_FormulaId",
                table: "Activities",
                column: "FormulaId",
                principalTable: "GradeFormulas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_GradeFormulas_FormulaId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_FormulaId",
                table: "Activities");

            migrationBuilder.AlterColumn<int>(
                name: "FormulaId",
                table: "Activities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_FormulaId",
                table: "Activities",
                column: "FormulaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_GradeFormulas_FormulaId",
                table: "Activities",
                column: "FormulaId",
                principalTable: "GradeFormulas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
