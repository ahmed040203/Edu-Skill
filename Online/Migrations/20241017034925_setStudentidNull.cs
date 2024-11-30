using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online.Migrations
{
    /// <inheritdoc />
    public partial class setStudentidNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardItems_Students_StudentId",
                table: "CardItems");

            migrationBuilder.DropIndex(
                name: "IX_CardItems_StudentId",
                table: "CardItems");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "CardItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_CardItems_StudentId",
                table: "CardItems",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CardItems_Students_StudentId",
                table: "CardItems",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardItems_Students_StudentId",
                table: "CardItems");

            migrationBuilder.DropIndex(
                name: "IX_CardItems_StudentId",
                table: "CardItems");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "CardItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardItems_StudentId",
                table: "CardItems",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CardItems_Students_StudentId",
                table: "CardItems",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
