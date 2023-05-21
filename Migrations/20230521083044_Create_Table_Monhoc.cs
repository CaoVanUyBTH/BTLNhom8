using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom8.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_Monhoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monhoc",
                columns: table => new
                {
                    Ma_mon = table.Column<string>(type: "TEXT", nullable: false),
                    Ten_mon = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monhoc", x => x.Ma_mon);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monhoc");
        }
    }
}
