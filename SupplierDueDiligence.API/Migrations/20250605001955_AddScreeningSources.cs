using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SupplierDueDiligence.API.Migrations
{
    /// <inheritdoc />
    public partial class AddScreeningSources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScreeningSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreeningSources", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ScreeningSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "OFAC", "OFAC" },
                    { 2, "WORLD_BANK", "World Bank" },
                    { 3, "OFFSHORE_LEAKS", "Offshore Leaks" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScreeningSources");
        }
    }
}
