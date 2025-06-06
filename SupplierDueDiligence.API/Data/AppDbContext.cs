
using Microsoft.EntityFrameworkCore;
using SupplierDueDiligence.API.Domain.Enums;
using SupplierDueDiligence.API.Domain.Models;

namespace SupplierDueDiligence.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<ScreeningSource> ScreeningSources => Set<ScreeningSource>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .Property(s => s.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .HasDefaultValueSql("NEWID()");

        modelBuilder.Entity<ScreeningSource>()
            .Property(e => e.Code)
            .HasConversion<string>();

        modelBuilder.Entity<Country>()
              .Property(s => s.Iso)
              .HasColumnType("char(2)")
              .IsFixedLength()
              .IsRequired(true);

        modelBuilder.Entity<Supplier>()
            .HasIndex(s => s.TaxId)
            .IsUnique();

        modelBuilder.Entity<Supplier>()
            .HasIndex(s => s.LastUpdated);

        modelBuilder.Entity<Supplier>()
            .Property(s => s.LastUpdated)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Supplier>()
            .Property(s => s.TaxId)
            .HasMaxLength(11);

        modelBuilder.Entity<Supplier>()
            .Property(s => s.AnnualRevenue)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Country>().HasData(
            new Country { Id = 1, Iso = "AF", Name = "Afganistán" },
            new Country { Id = 2, Iso = "AX", Name = "Islas Gland" },
            new Country { Id = 3, Iso = "AL", Name = "Albania" },
            new Country { Id = 4, Iso = "DE", Name = "Alemania" },
            new Country { Id = 5, Iso = "AD", Name = "Andorra" },
            new Country { Id = 6, Iso = "AO", Name = "Angola" },
            new Country { Id = 7, Iso = "AI", Name = "Anguilla" },
            new Country { Id = 8, Iso = "AQ", Name = "Antártida" },
            new Country { Id = 9, Iso = "AG", Name = "Antigua y Barbuda" },
            new Country { Id = 10, Iso = "AN", Name = "Antillas Holandesas" },
            new Country { Id = 11, Iso = "SA", Name = "Arabia Saudí" },
            new Country { Id = 12, Iso = "DZ", Name = "Argelia" },
            new Country { Id = 13, Iso = "AR", Name = "Argentina" },
            new Country { Id = 14, Iso = "AM", Name = "Armenia" },
            new Country { Id = 15, Iso = "AW", Name = "Aruba" },
            new Country { Id = 16, Iso = "AU", Name = "Australia" },
            new Country { Id = 17, Iso = "AT", Name = "Austria" },
            new Country { Id = 18, Iso = "AZ", Name = "Azerbaiyán" },
            new Country { Id = 19, Iso = "BS", Name = "Bahamas" },
            new Country { Id = 20, Iso = "BH", Name = "Bahréin" },
            new Country { Id = 21, Iso = "BD", Name = "Bangladesh" },
            new Country { Id = 22, Iso = "BB", Name = "Barbados" },
            new Country { Id = 23, Iso = "BY", Name = "Bielorrusia" },
            new Country { Id = 24, Iso = "BE", Name = "Bélgica" },
            new Country { Id = 25, Iso = "BZ", Name = "Belice" },
            new Country { Id = 26, Iso = "BJ", Name = "Benin" },
            new Country { Id = 27, Iso = "BM", Name = "Bermudas" },
            new Country { Id = 28, Iso = "BT", Name = "Bhután" },
            new Country { Id = 29, Iso = "BO", Name = "Bolivia" },
            new Country { Id = 30, Iso = "BA", Name = "Bosnia y Herzegovina" },
            new Country { Id = 31, Iso = "BW", Name = "Botsuana" },
            new Country { Id = 32, Iso = "BV", Name = "Isla Bouvet" },
            new Country { Id = 33, Iso = "BR", Name = "Brasil" },
            new Country { Id = 34, Iso = "BN", Name = "Brunéi" },
            new Country { Id = 35, Iso = "BG", Name = "Bulgaria" },
            new Country { Id = 36, Iso = "BF", Name = "Burkina Faso" },
            new Country { Id = 37, Iso = "BI", Name = "Burundi" },
            new Country { Id = 38, Iso = "CV", Name = "Cabo Verde" },
            new Country { Id = 39, Iso = "KY", Name = "Islas Caimán" },
            new Country { Id = 40, Iso = "KH", Name = "Camboya" },
            new Country { Id = 41, Iso = "CM", Name = "Camerún" },
            new Country { Id = 42, Iso = "CA", Name = "Canadá" },
            new Country { Id = 43, Iso = "CF", Name = "República Centroafricana" },
            new Country { Id = 44, Iso = "TD", Name = "Chad" },
            new Country { Id = 45, Iso = "CZ", Name = "República Checa" },
            new Country { Id = 46, Iso = "CL", Name = "Chile" },
            new Country { Id = 47, Iso = "CN", Name = "China" },
            new Country { Id = 48, Iso = "CY", Name = "Chipre" },
            new Country { Id = 49, Iso = "CX", Name = "Isla de Navidad" },
            new Country { Id = 50, Iso = "VA", Name = "Ciudad del Vaticano" },
            new Country { Id = 51, Iso = "CC", Name = "Islas Cocos" },
            new Country { Id = 52, Iso = "CO", Name = "Colombia" },
            new Country { Id = 53, Iso = "KM", Name = "Comoras" },
            new Country { Id = 54, Iso = "CD", Name = "República Democrática del Congo" },
            new Country { Id = 55, Iso = "CG", Name = "Congo" },
            new Country { Id = 56, Iso = "CK", Name = "Islas Cook" },
            new Country { Id = 57, Iso = "KP", Name = "Corea del Norte" },
            new Country { Id = 58, Iso = "KR", Name = "Corea del Sur" },
            new Country { Id = 59, Iso = "CI", Name = "Costa de Marfil" },
            new Country { Id = 60, Iso = "CR", Name = "Costa Rica" },
            new Country { Id = 61, Iso = "HR", Name = "Croacia" },
            new Country { Id = 62, Iso = "CU", Name = "Cuba" },
            new Country { Id = 63, Iso = "DK", Name = "Dinamarca" },
            new Country { Id = 64, Iso = "DM", Name = "Dominica" },
            new Country { Id = 65, Iso = "DO", Name = "República Dominicana" },
            new Country { Id = 66, Iso = "EC", Name = "Ecuador" },
            new Country { Id = 67, Iso = "EG", Name = "Egipto" },
            new Country { Id = 68, Iso = "SV", Name = "El Salvador" },
            new Country { Id = 69, Iso = "AE", Name = "Emiratos Árabes Unidos" },
            new Country { Id = 70, Iso = "ER", Name = "Eritrea" },
            new Country { Id = 71, Iso = "SK", Name = "Eslovaquia" },
            new Country { Id = 72, Iso = "SI", Name = "Eslovenia" },
            new Country { Id = 73, Iso = "ES", Name = "España" },
            new Country { Id = 74, Iso = "UM", Name = "Islas ultramarinas de Estados Unidos" },
            new Country { Id = 75, Iso = "US", Name = "Estados Unidos" },
            new Country { Id = 76, Iso = "EE", Name = "Estonia" },
            new Country { Id = 77, Iso = "ET", Name = "Etiopía" },
            new Country { Id = 78, Iso = "FO", Name = "Islas Feroe" },
            new Country { Id = 79, Iso = "PH", Name = "Filipinas" },
            new Country { Id = 80, Iso = "FI", Name = "Finlandia" },
            new Country { Id = 81, Iso = "FJ", Name = "Fiyi" },
            new Country { Id = 82, Iso = "FR", Name = "Francia" },
            new Country { Id = 83, Iso = "GA", Name = "Gabón" },
            new Country { Id = 84, Iso = "GM", Name = "Gambia" },
            new Country { Id = 85, Iso = "GE", Name = "Georgia" },
            new Country { Id = 86, Iso = "GS", Name = "Islas Georgias del Sur y Sandwich del Sur" },
            new Country { Id = 87, Iso = "GH", Name = "Ghana" },
            new Country { Id = 88, Iso = "GI", Name = "Gibraltar" },
            new Country { Id = 89, Iso = "GD", Name = "Granada" },
            new Country { Id = 90, Iso = "GR", Name = "Grecia" },
            new Country { Id = 91, Iso = "GL", Name = "Groenlandia" },
            new Country { Id = 92, Iso = "GP", Name = "Guadalupe" },
            new Country { Id = 93, Iso = "GU", Name = "Guam" },
            new Country { Id = 94, Iso = "GT", Name = "Guatemala" },
            new Country { Id = 95, Iso = "GF", Name = "Guayana Francesa" },
            new Country { Id = 96, Iso = "GN", Name = "Guinea" },
            new Country { Id = 97, Iso = "GQ", Name = "Guinea Ecuatorial" },
            new Country { Id = 98, Iso = "GW", Name = "Guinea-Bissau" },
            new Country { Id = 99, Iso = "GY", Name = "Guyana" },
            new Country { Id = 100, Iso = "HT", Name = "Haití" },
            new Country { Id = 101, Iso = "HM", Name = "Islas Heard y McDonald" },
            new Country { Id = 102, Iso = "HN", Name = "Honduras" },
            new Country { Id = 103, Iso = "HK", Name = "Hong Kong" },
            new Country { Id = 104, Iso = "HU", Name = "Hungría" },
            new Country { Id = 105, Iso = "IN", Name = "India" },
            new Country { Id = 106, Iso = "ID", Name = "Indonesia" },
            new Country { Id = 107, Iso = "IR", Name = "Irán" },
            new Country { Id = 108, Iso = "IQ", Name = "Iraq" },
            new Country { Id = 109, Iso = "IE", Name = "Irlanda" },
            new Country { Id = 110, Iso = "IS", Name = "Islandia" },
            new Country { Id = 111, Iso = "IL", Name = "Israel" },
            new Country { Id = 112, Iso = "IT", Name = "Italia" },
            new Country { Id = 113, Iso = "JM", Name = "Jamaica" },
            new Country { Id = 114, Iso = "JP", Name = "Japón" },
            new Country { Id = 115, Iso = "JO", Name = "Jordania" },
            new Country { Id = 116, Iso = "KZ", Name = "Kazajstán" },
            new Country { Id = 117, Iso = "KE", Name = "Kenia" },
            new Country { Id = 118, Iso = "KG", Name = "Kirguistán" },
            new Country { Id = 119, Iso = "KI", Name = "Kiribati" },
            new Country { Id = 120, Iso = "KW", Name = "Kuwait" },
            new Country { Id = 121, Iso = "LA", Name = "Laos" },
            new Country { Id = 122, Iso = "LS", Name = "Lesotho" },
            new Country { Id = 123, Iso = "LV", Name = "Letonia" },
            new Country { Id = 124, Iso = "LB", Name = "Líbano" },
            new Country { Id = 125, Iso = "LR", Name = "Liberia" },
            new Country { Id = 126, Iso = "LY", Name = "Libia" },
            new Country { Id = 127, Iso = "LI", Name = "Liechtenstein" },
            new Country { Id = 128, Iso = "LT", Name = "Lituania" },
            new Country { Id = 129, Iso = "LU", Name = "Luxemburgo" },
            new Country { Id = 130, Iso = "MO", Name = "Macao" },
            new Country { Id = 131, Iso = "MK", Name = "ARY Macedonia" },
            new Country { Id = 132, Iso = "MG", Name = "Madagascar" },
            new Country { Id = 133, Iso = "MY", Name = "Malasia" },
            new Country { Id = 134, Iso = "MW", Name = "Malawi" },
            new Country { Id = 135, Iso = "MV", Name = "Maldivas" },
            new Country { Id = 136, Iso = "ML", Name = "Malí" },
            new Country { Id = 137, Iso = "MT", Name = "Malta" },
            new Country { Id = 138, Iso = "FK", Name = "Islas Malvinas" },
            new Country { Id = 139, Iso = "MP", Name = "Islas Marianas del Norte" },
            new Country { Id = 140, Iso = "MA", Name = "Marruecos" },
            new Country { Id = 141, Iso = "MH", Name = "Islas Marshall" },
            new Country { Id = 142, Iso = "MQ", Name = "Martinica" },
            new Country { Id = 143, Iso = "MU", Name = "Mauricio" },
            new Country { Id = 144, Iso = "MR", Name = "Mauritania" },
            new Country { Id = 145, Iso = "YT", Name = "Mayotte" },
            new Country { Id = 146, Iso = "MX", Name = "México" },
            new Country { Id = 147, Iso = "FM", Name = "Micronesia" },
            new Country { Id = 148, Iso = "MD", Name = "Moldavia" },
            new Country { Id = 149, Iso = "MC", Name = "Mónaco" },
            new Country { Id = 150, Iso = "MN", Name = "Mongolia" },
            new Country { Id = 151, Iso = "MS", Name = "Montserrat" },
            new Country { Id = 152, Iso = "MZ", Name = "Mozambique" },
            new Country { Id = 153, Iso = "MM", Name = "Myanmar" },
            new Country { Id = 154, Iso = "NA", Name = "Namibia" },
            new Country { Id = 155, Iso = "NR", Name = "Nauru" },
            new Country { Id = 156, Iso = "NP", Name = "Nepal" },
            new Country { Id = 157, Iso = "NI", Name = "Nicaragua" },
            new Country { Id = 158, Iso = "NE", Name = "Níger" },
            new Country { Id = 159, Iso = "NG", Name = "Nigeria" },
            new Country { Id = 160, Iso = "NU", Name = "Niue" },
            new Country { Id = 161, Iso = "NF", Name = "Isla Norfolk" },
            new Country { Id = 162, Iso = "NO", Name = "Noruega" },
            new Country { Id = 163, Iso = "NC", Name = "Nueva Caledonia" },
            new Country { Id = 164, Iso = "NZ", Name = "Nueva Zelanda" },
            new Country { Id = 165, Iso = "OM", Name = "Omán" },
            new Country { Id = 166, Iso = "NL", Name = "Países Bajos" },
            new Country { Id = 167, Iso = "PK", Name = "Pakistán" },
            new Country { Id = 168, Iso = "PW", Name = "Palau" },
            new Country { Id = 169, Iso = "PS", Name = "Palestina" },
            new Country { Id = 170, Iso = "PA", Name = "Panamá" },
            new Country { Id = 171, Iso = "PG", Name = "Papúa Nueva Guinea" },
            new Country { Id = 172, Iso = "PY", Name = "Paraguay" },
            new Country { Id = 173, Iso = "PE", Name = "Perú" },
            new Country { Id = 174, Iso = "PN", Name = "Islas Pitcairn" },
            new Country { Id = 175, Iso = "PF", Name = "Polinesia Francesa" },
            new Country { Id = 176, Iso = "PL", Name = "Polonia" },
            new Country { Id = 177, Iso = "PT", Name = "Portugal" },
            new Country { Id = 178, Iso = "PR", Name = "Puerto Rico" },
            new Country { Id = 179, Iso = "QA", Name = "Qatar" },
            new Country { Id = 180, Iso = "GB", Name = "Reino Unido" },
            new Country { Id = 181, Iso = "RE", Name = "Reunión" },
            new Country { Id = 182, Iso = "RW", Name = "Ruanda" },
            new Country { Id = 183, Iso = "RO", Name = "Rumania" },
            new Country { Id = 184, Iso = "RU", Name = "Rusia" },
            new Country { Id = 185, Iso = "EH", Name = "Sahara Occidental" },
            new Country { Id = 186, Iso = "SB", Name = "Islas Salomón" },
            new Country { Id = 187, Iso = "WS", Name = "Samoa" },
            new Country { Id = 188, Iso = "AS", Name = "Samoa Americana" },
            new Country { Id = 189, Iso = "KN", Name = "San Cristóbal y Nevis" },
            new Country { Id = 190, Iso = "SM", Name = "San Marino" },
            new Country { Id = 191, Iso = "PM", Name = "San Pedro y Miquelón" },
            new Country { Id = 192, Iso = "VC", Name = "San Vicente y las Granadinas" },
            new Country { Id = 193, Iso = "SH", Name = "Santa Helena" },
            new Country { Id = 194, Iso = "LC", Name = "Santa Lucía" },
            new Country { Id = 195, Iso = "ST", Name = "Santo Tomé y Príncipe" },
            new Country { Id = 196, Iso = "SN", Name = "Senegal" },
            new Country { Id = 197, Iso = "CS", Name = "Serbia y Montenegro" },
            new Country { Id = 198, Iso = "SC", Name = "Seychelles" },
            new Country { Id = 199, Iso = "SL", Name = "Sierra Leona" },
            new Country { Id = 200, Iso = "SG", Name = "Singapur" },
            new Country { Id = 201, Iso = "SY", Name = "Siria" },
            new Country { Id = 202, Iso = "SO", Name = "Somalia" },
            new Country { Id = 203, Iso = "LK", Name = "Sri Lanka" },
            new Country { Id = 204, Iso = "SZ", Name = "Suazilandia" },
            new Country { Id = 205, Iso = "ZA", Name = "Sudáfrica" },
            new Country { Id = 206, Iso = "SD", Name = "Sudán" },
            new Country { Id = 207, Iso = "SE", Name = "Suecia" },
            new Country { Id = 208, Iso = "CH", Name = "Suiza" },
            new Country { Id = 209, Iso = "SR", Name = "Surinam" },
            new Country { Id = 210, Iso = "SJ", Name = "Svalbard y Jan Mayen" },
            new Country { Id = 211, Iso = "TH", Name = "Tailandia" },
            new Country { Id = 212, Iso = "TW", Name = "Taiwán" },
            new Country { Id = 213, Iso = "TZ", Name = "Tanzania" },
            new Country { Id = 214, Iso = "TJ", Name = "Tayikistán" },
            new Country { Id = 215, Iso = "IO", Name = "Territorio Británico del Océano Índico" },
            new Country { Id = 216, Iso = "TF", Name = "Territorios Australes Franceses" },
            new Country { Id = 217, Iso = "TL", Name = "Timor Oriental" },
            new Country { Id = 218, Iso = "TG", Name = "Togo" },
            new Country { Id = 219, Iso = "TK", Name = "Tokelau" },
            new Country { Id = 220, Iso = "TO", Name = "Tonga" },
            new Country { Id = 221, Iso = "TT", Name = "Trinidad y Tobago" },
            new Country { Id = 222, Iso = "TN", Name = "Túnez" },
            new Country { Id = 223, Iso = "TC", Name = "Islas Turcas y Caicos" },
            new Country { Id = 224, Iso = "TM", Name = "Turkmenistán" },
            new Country { Id = 225, Iso = "TR", Name = "Turquía" },
            new Country { Id = 226, Iso = "TV", Name = "Tuvalu" },
            new Country { Id = 227, Iso = "UA", Name = "Ucrania" },
            new Country { Id = 228, Iso = "UG", Name = "Uganda" },
            new Country { Id = 229, Iso = "UY", Name = "Uruguay" },
            new Country { Id = 230, Iso = "UZ", Name = "Uzbekistán" },
            new Country { Id = 231, Iso = "VU", Name = "Vanuatu" },
            new Country { Id = 232, Iso = "VE", Name = "Venezuela" },
            new Country { Id = 233, Iso = "VN", Name = "Vietnam" },
            new Country { Id = 234, Iso = "VG", Name = "Islas Vírgenes Británicas" },
            new Country { Id = 235, Iso = "VI", Name = "Islas Vírgenes de los Estados Unidos" },
            new Country { Id = 236, Iso = "WF", Name = "Wallis y Futuna" },
            new Country { Id = 237, Iso = "YE", Name = "Yemen" },
            new Country { Id = 238, Iso = "DJ", Name = "Yibuti" },
            new Country { Id = 239, Iso = "ZM", Name = "Zambia" },
            new Country { Id = 240, Iso = "ZW", Name = "Zimbabue" }
        );

        modelBuilder.Entity<Supplier>().HasData(
            new Supplier
            {
                Id = 1,
                BusinessName = "Tech Solutions SA",
                CommercialName = "TechSol",
                TaxId = "12345678901",
                PhoneNumber = "+525512345678",
                Email = "contact@techsol.com",
                Website = "https://techsol.com",
                Address = "Av. Reforma 123",
                CountryId = 2,
                AnnualRevenue = 500000.00m,
            },
            new Supplier
            {
                Id = 2,
                BusinessName = "Global Logistics",
                CommercialName = "LogGlobal",
                TaxId = "98765432109",
                PhoneNumber = "+34987654321",
                Email = "info@logglobal.es",
                Website = "https://logglobal.es",
                Address = "Calle Mayor 45",
                CountryId = 3,
                AnnualRevenue = 750000.00m
            },
            new Supplier
            {
                Id = 3,
                BusinessName = "Offshore Investments",
                CommercialName = "Offshore Corp",
                TaxId = "11122334455",
                PhoneNumber = "+5076543210",
                Email = "admin@offshore.pa",
                Website = "https://offshore.pa",
                Address = "Calle 50, Panama",
                CountryId = 5,
                AnnualRevenue = 2000000.00m
            }
        );

        modelBuilder.Entity<ScreeningSource>().HasData(
               new ScreeningSource { Id = 1, Name = "OFAC", Code = ScreeningSourceCode.OFAC, Enable = true },
               new ScreeningSource { Id = 2, Name = "World Bank", Code = ScreeningSourceCode.WORLD_BANK, Enable = true },
               new ScreeningSource { Id = 3, Name = "Offshore Leaks", Code = ScreeningSourceCode.OFFSHORE_LEAKS, Enable = false }
           );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.Parse("C2E88754-02E8-4CE2-962A-9C56501118B0"),
                Username = "maria.garcia",
                Email = "maria.garcia@example.com",
                PasswordHash = "AQAAAAIAAYagAAAAEDJ5VZasQzvI+Z54io94cso6jboPFIeTHCKoqVxCfXOvDscFygcrO6dRibNSxss/og==", // mariapassword
            },
            new User
            {
                Id = Guid.Parse("CFAA81F3-80A1-4E52-BCA6-096B2BD8104D"),
                Username = "carlos_ramirez",
                Email = "carlos.ramirez@example.com",
                PasswordHash = "AQAAAAIAAYagAAAAEKJkf4qEzYgZiKR9N2QWt3GK2S8KGI2UZrydbO696D+WdyOd0HjCB4uoYdyhvejgeQ==", // Secure*456
            }
        );

    }
}