using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom8.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_Subject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Student_StudentID",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_StudentID",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Subject");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentID",
                table: "Subject",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_StudentID",
                table: "Subject",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Student_StudentID",
                table: "Subject",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
