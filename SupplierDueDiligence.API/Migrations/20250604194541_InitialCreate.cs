using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SupplierDueDiligence.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iso = table.Column<string>(type: "char(2)", fixedLength: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommercialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    AnnualRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Iso", "Name" },
                values: new object[,]
                {
                    { 1, "AF", "Afganistán" },
                    { 2, "AX", "Islas Gland" },
                    { 3, "AL", "Albania" },
                    { 4, "DE", "Alemania" },
                    { 5, "AD", "Andorra" },
                    { 6, "AO", "Angola" },
                    { 7, "AI", "Anguilla" },
                    { 8, "AQ", "Antártida" },
                    { 9, "AG", "Antigua y Barbuda" },
                    { 10, "AN", "Antillas Holandesas" },
                    { 11, "SA", "Arabia Saudí" },
                    { 12, "DZ", "Argelia" },
                    { 13, "AR", "Argentina" },
                    { 14, "AM", "Armenia" },
                    { 15, "AW", "Aruba" },
                    { 16, "AU", "Australia" },
                    { 17, "AT", "Austria" },
                    { 18, "AZ", "Azerbaiyán" },
                    { 19, "BS", "Bahamas" },
                    { 20, "BH", "Bahréin" },
                    { 21, "BD", "Bangladesh" },
                    { 22, "BB", "Barbados" },
                    { 23, "BY", "Bielorrusia" },
                    { 24, "BE", "Bélgica" },
                    { 25, "BZ", "Belice" },
                    { 26, "BJ", "Benin" },
                    { 27, "BM", "Bermudas" },
                    { 28, "BT", "Bhután" },
                    { 29, "BO", "Bolivia" },
                    { 30, "BA", "Bosnia y Herzegovina" },
                    { 31, "BW", "Botsuana" },
                    { 32, "BV", "Isla Bouvet" },
                    { 33, "BR", "Brasil" },
                    { 34, "BN", "Brunéi" },
                    { 35, "BG", "Bulgaria" },
                    { 36, "BF", "Burkina Faso" },
                    { 37, "BI", "Burundi" },
                    { 38, "CV", "Cabo Verde" },
                    { 39, "KY", "Islas Caimán" },
                    { 40, "KH", "Camboya" },
                    { 41, "CM", "Camerún" },
                    { 42, "CA", "Canadá" },
                    { 43, "CF", "República Centroafricana" },
                    { 44, "TD", "Chad" },
                    { 45, "CZ", "República Checa" },
                    { 46, "CL", "Chile" },
                    { 47, "CN", "China" },
                    { 48, "CY", "Chipre" },
                    { 49, "CX", "Isla de Navidad" },
                    { 50, "VA", "Ciudad del Vaticano" },
                    { 51, "CC", "Islas Cocos" },
                    { 52, "CO", "Colombia" },
                    { 53, "KM", "Comoras" },
                    { 54, "CD", "República Democrática del Congo" },
                    { 55, "CG", "Congo" },
                    { 56, "CK", "Islas Cook" },
                    { 57, "KP", "Corea del Norte" },
                    { 58, "KR", "Corea del Sur" },
                    { 59, "CI", "Costa de Marfil" },
                    { 60, "CR", "Costa Rica" },
                    { 61, "HR", "Croacia" },
                    { 62, "CU", "Cuba" },
                    { 63, "DK", "Dinamarca" },
                    { 64, "DM", "Dominica" },
                    { 65, "DO", "República Dominicana" },
                    { 66, "EC", "Ecuador" },
                    { 67, "EG", "Egipto" },
                    { 68, "SV", "El Salvador" },
                    { 69, "AE", "Emiratos Árabes Unidos" },
                    { 70, "ER", "Eritrea" },
                    { 71, "SK", "Eslovaquia" },
                    { 72, "SI", "Eslovenia" },
                    { 73, "ES", "España" },
                    { 74, "UM", "Islas ultramarinas de Estados Unidos" },
                    { 75, "US", "Estados Unidos" },
                    { 76, "EE", "Estonia" },
                    { 77, "ET", "Etiopía" },
                    { 78, "FO", "Islas Feroe" },
                    { 79, "PH", "Filipinas" },
                    { 80, "FI", "Finlandia" },
                    { 81, "FJ", "Fiyi" },
                    { 82, "FR", "Francia" },
                    { 83, "GA", "Gabón" },
                    { 84, "GM", "Gambia" },
                    { 85, "GE", "Georgia" },
                    { 86, "GS", "Islas Georgias del Sur y Sandwich del Sur" },
                    { 87, "GH", "Ghana" },
                    { 88, "GI", "Gibraltar" },
                    { 89, "GD", "Granada" },
                    { 90, "GR", "Grecia" },
                    { 91, "GL", "Groenlandia" },
                    { 92, "GP", "Guadalupe" },
                    { 93, "GU", "Guam" },
                    { 94, "GT", "Guatemala" },
                    { 95, "GF", "Guayana Francesa" },
                    { 96, "GN", "Guinea" },
                    { 97, "GQ", "Guinea Ecuatorial" },
                    { 98, "GW", "Guinea-Bissau" },
                    { 99, "GY", "Guyana" },
                    { 100, "HT", "Haití" },
                    { 101, "HM", "Islas Heard y McDonald" },
                    { 102, "HN", "Honduras" },
                    { 103, "HK", "Hong Kong" },
                    { 104, "HU", "Hungría" },
                    { 105, "IN", "India" },
                    { 106, "ID", "Indonesia" },
                    { 107, "IR", "Irán" },
                    { 108, "IQ", "Iraq" },
                    { 109, "IE", "Irlanda" },
                    { 110, "IS", "Islandia" },
                    { 111, "IL", "Israel" },
                    { 112, "IT", "Italia" },
                    { 113, "JM", "Jamaica" },
                    { 114, "JP", "Japón" },
                    { 115, "JO", "Jordania" },
                    { 116, "KZ", "Kazajstán" },
                    { 117, "KE", "Kenia" },
                    { 118, "KG", "Kirguistán" },
                    { 119, "KI", "Kiribati" },
                    { 120, "KW", "Kuwait" },
                    { 121, "LA", "Laos" },
                    { 122, "LS", "Lesotho" },
                    { 123, "LV", "Letonia" },
                    { 124, "LB", "Líbano" },
                    { 125, "LR", "Liberia" },
                    { 126, "LY", "Libia" },
                    { 127, "LI", "Liechtenstein" },
                    { 128, "LT", "Lituania" },
                    { 129, "LU", "Luxemburgo" },
                    { 130, "MO", "Macao" },
                    { 131, "MK", "ARY Macedonia" },
                    { 132, "MG", "Madagascar" },
                    { 133, "MY", "Malasia" },
                    { 134, "MW", "Malawi" },
                    { 135, "MV", "Maldivas" },
                    { 136, "ML", "Malí" },
                    { 137, "MT", "Malta" },
                    { 138, "FK", "Islas Malvinas" },
                    { 139, "MP", "Islas Marianas del Norte" },
                    { 140, "MA", "Marruecos" },
                    { 141, "MH", "Islas Marshall" },
                    { 142, "MQ", "Martinica" },
                    { 143, "MU", "Mauricio" },
                    { 144, "MR", "Mauritania" },
                    { 145, "YT", "Mayotte" },
                    { 146, "MX", "México" },
                    { 147, "FM", "Micronesia" },
                    { 148, "MD", "Moldavia" },
                    { 149, "MC", "Mónaco" },
                    { 150, "MN", "Mongolia" },
                    { 151, "MS", "Montserrat" },
                    { 152, "MZ", "Mozambique" },
                    { 153, "MM", "Myanmar" },
                    { 154, "NA", "Namibia" },
                    { 155, "NR", "Nauru" },
                    { 156, "NP", "Nepal" },
                    { 157, "NI", "Nicaragua" },
                    { 158, "NE", "Níger" },
                    { 159, "NG", "Nigeria" },
                    { 160, "NU", "Niue" },
                    { 161, "NF", "Isla Norfolk" },
                    { 162, "NO", "Noruega" },
                    { 163, "NC", "Nueva Caledonia" },
                    { 164, "NZ", "Nueva Zelanda" },
                    { 165, "OM", "Omán" },
                    { 166, "NL", "Países Bajos" },
                    { 167, "PK", "Pakistán" },
                    { 168, "PW", "Palau" },
                    { 169, "PS", "Palestina" },
                    { 170, "PA", "Panamá" },
                    { 171, "PG", "Papúa Nueva Guinea" },
                    { 172, "PY", "Paraguay" },
                    { 173, "PE", "Perú" },
                    { 174, "PN", "Islas Pitcairn" },
                    { 175, "PF", "Polinesia Francesa" },
                    { 176, "PL", "Polonia" },
                    { 177, "PT", "Portugal" },
                    { 178, "PR", "Puerto Rico" },
                    { 179, "QA", "Qatar" },
                    { 180, "GB", "Reino Unido" },
                    { 181, "RE", "Reunión" },
                    { 182, "RW", "Ruanda" },
                    { 183, "RO", "Rumania" },
                    { 184, "RU", "Rusia" },
                    { 185, "EH", "Sahara Occidental" },
                    { 186, "SB", "Islas Salomón" },
                    { 187, "WS", "Samoa" },
                    { 188, "AS", "Samoa Americana" },
                    { 189, "KN", "San Cristóbal y Nevis" },
                    { 190, "SM", "San Marino" },
                    { 191, "PM", "San Pedro y Miquelón" },
                    { 192, "VC", "San Vicente y las Granadinas" },
                    { 193, "SH", "Santa Helena" },
                    { 194, "LC", "Santa Lucía" },
                    { 195, "ST", "Santo Tomé y Príncipe" },
                    { 196, "SN", "Senegal" },
                    { 197, "CS", "Serbia y Montenegro" },
                    { 198, "SC", "Seychelles" },
                    { 199, "SL", "Sierra Leona" },
                    { 200, "SG", "Singapur" },
                    { 201, "SY", "Siria" },
                    { 202, "SO", "Somalia" },
                    { 203, "LK", "Sri Lanka" },
                    { 204, "SZ", "Suazilandia" },
                    { 205, "ZA", "Sudáfrica" },
                    { 206, "SD", "Sudán" },
                    { 207, "SE", "Suecia" },
                    { 208, "CH", "Suiza" },
                    { 209, "SR", "Surinam" },
                    { 210, "SJ", "Svalbard y Jan Mayen" },
                    { 211, "TH", "Tailandia" },
                    { 212, "TW", "Taiwán" },
                    { 213, "TZ", "Tanzania" },
                    { 214, "TJ", "Tayikistán" },
                    { 215, "IO", "Territorio Británico del Océano Índico" },
                    { 216, "TF", "Territorios Australes Franceses" },
                    { 217, "TL", "Timor Oriental" },
                    { 218, "TG", "Togo" },
                    { 219, "TK", "Tokelau" },
                    { 220, "TO", "Tonga" },
                    { 221, "TT", "Trinidad y Tobago" },
                    { 222, "TN", "Túnez" },
                    { 223, "TC", "Islas Turcas y Caicos" },
                    { 224, "TM", "Turkmenistán" },
                    { 225, "TR", "Turquía" },
                    { 226, "TV", "Tuvalu" },
                    { 227, "UA", "Ucrania" },
                    { 228, "UG", "Uganda" },
                    { 229, "UY", "Uruguay" },
                    { 230, "UZ", "Uzbekistán" },
                    { 231, "VU", "Vanuatu" },
                    { 232, "VE", "Venezuela" },
                    { 233, "VN", "Vietnam" },
                    { 234, "VG", "Islas Vírgenes Británicas" },
                    { 235, "VI", "Islas Vírgenes de los Estados Unidos" },
                    { 236, "WF", "Wallis y Futuna" },
                    { 237, "YE", "Yemen" },
                    { 238, "DJ", "Yibuti" },
                    { 239, "ZM", "Zambia" },
                    { 240, "ZW", "Zimbabue" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "AnnualRevenue", "BusinessName", "CommercialName", "CountryId", "Email", "PhoneNumber", "TaxId", "Website" },
                values: new object[,]
                {
                    { 1, "Av. Reforma 123", 500000.00m, "Tech Solutions SA", "TechSol", 2, "contact@techsol.com", "+525512345678", "12345678901", "https://techsol.com" },
                    { 2, "Calle Mayor 45", 750000.00m, "Global Logistics", "LogGlobal", 3, "info@logglobal.es", "+34987654321", "98765432109", "https://logglobal.es" },
                    { 3, "Calle 50, Panama", 2000000.00m, "Offshore Investments", "Offshore Corp", 5, "admin@offshore.pa", "+5076543210", "11122334455", "https://offshore.pa" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CountryId",
                table: "Suppliers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_LastUpdated",
                table: "Suppliers",
                column: "LastUpdated");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_TaxId",
                table: "Suppliers",
                column: "TaxId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
