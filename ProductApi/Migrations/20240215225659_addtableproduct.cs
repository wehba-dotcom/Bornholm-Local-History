using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class addtableproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaesterTilNavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForrigeFaesterNavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kommentarer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gaard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sogn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaestebrevUdstedt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Side = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
