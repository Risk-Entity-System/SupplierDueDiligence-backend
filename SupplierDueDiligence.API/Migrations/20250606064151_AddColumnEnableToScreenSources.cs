using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplierDueDiligence.API.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnEnableToScreenSources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "ScreeningSources",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ScreeningSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Enable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ScreeningSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "Enable",
                value: true);

            migrationBuilder.UpdateData(
                table: "ScreeningSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "Enable",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enable",
                table: "ScreeningSources");
        }
    }
}
