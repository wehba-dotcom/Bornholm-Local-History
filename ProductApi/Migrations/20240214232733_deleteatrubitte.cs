using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class deleteatrubitte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FastningBooks_Book_bookId",
                table: "FastningBooks");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.RenameColumn(
                name: "bookId",
                table: "FastningBooks",
                newName: "bogId");

            migrationBuilder.RenameIndex(
                name: "IX_FastningBooks_bookId",
                table: "FastningBooks",
                newName: "IX_FastningBooks_bogId");

            migrationBuilder.CreateTable(
                name: "Bog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bog = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bind = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bog", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FastningBooks_Bog_bogId",
                table: "FastningBooks",
                column: "bogId",
                principalTable: "Bog",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FastningBooks_Bog_bogId",
                table: "FastningBooks");

            migrationBuilder.DropTable(
                name: "Bog");

            migrationBuilder.RenameColumn(
                name: "bogId",
                table: "FastningBooks",
                newName: "bookId");

            migrationBuilder.RenameIndex(
                name: "IX_FastningBooks_bogId",
                table: "FastningBooks",
                newName: "IX_FastningBooks_bookId");

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bind = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bog = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FastningBooks_Book_bookId",
                table: "FastningBooks",
                column: "bookId",
                principalTable: "Book",
                principalColumn: "Id");
        }
    }
}
