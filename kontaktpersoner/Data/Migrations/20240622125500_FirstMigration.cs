using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace kontaktpersoner.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KontaktPersoner",
                columns: table => new
                {
                    KontaktId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Navn = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KontaktPersoner", x => x.KontaktId);
                });

            migrationBuilder.InsertData(
                table: "KontaktPersoner",
                columns: new[] { "KontaktId", "Adresse", "Email", "Navn", "Telefon" },
                values: new object[,]
                {
                    { 1, "Adresse 1", "Email 1", "Person 1", "Telefon 1" },
                    { 2, "Adresse 2", "Email 2", "Person 2", "Telefon 2" },
                    { 3, "Adresse 3", "Email 3", "Person 3", "Telefon 3" },
                    { 4, "Adresse 4", "Email 4", "Person 4", "Telefon 4" },
                    { 5, "Adresse 5", "Email 5", "Person 5", "Telefon 5" },
                    { 6, "Adresse 6", "Email 6", "Person 6", "Telefon 6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KontaktPersoner");
        }
    }
}
