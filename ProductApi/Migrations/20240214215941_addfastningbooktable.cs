using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class addfastningbooktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    Bog = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bind = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FastningBooks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Indskrivningsnr = table.Column<int>(type: "int", nullable: true),
                    FaesterNavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fornavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efternavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaesterTilNavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForrigeFaesterNavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForrigeFaesterForNavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForrigeFaesterEfterNavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForrigeFaesterTilNavnmm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kommentarer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gaard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sogn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaestebrevUdstedt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Side = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bookId = table.Column<int>(type: "int", nullable: true),
                    Film = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Herred = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FastningBooks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FastningBooks_Book_bookId",
                        column: x => x.bookId,
                        principalTable: "Book",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FastningBooks_bookId",
                table: "FastningBooks",
                column: "bookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FastningBooks");

            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
