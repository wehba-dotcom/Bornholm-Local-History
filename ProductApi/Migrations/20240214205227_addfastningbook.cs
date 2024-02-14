using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class addfastningbook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Film = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Herred = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FastningBooks", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FastningBooks");
        }
    }
}
