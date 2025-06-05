using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SupplierDueDiligence.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { new Guid("c2e88754-02e8-4ce2-962a-9c56501118b0"), "maria.garcia@example.com", "AQAAAAIAAYagAAAAEDJ5VZasQzvI+Z54io94cso6jboPFIeTHCKoqVxCfXOvDscFygcrO6dRibNSxss/og==", "maria.garcia" },
                    { new Guid("cfaa81f3-80a1-4e52-bca6-096b2bd8104d"), "carlos.ramirez@example.com", "AQAAAAIAAYagAAAAEKJkf4qEzYgZiKR9N2QWt3GK2S8KGI2UZrydbO696D+WdyOd0HjCB4uoYdyhvejgeQ==", "carlos_ramirez" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
