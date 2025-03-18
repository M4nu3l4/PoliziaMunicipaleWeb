using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cops.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anagrafica",
                columns: table => new
                {
                    IdAnagrafica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Citta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CAP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cod_Fisc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PuntiDecurtati = table.Column<int>(type: "int", nullable: false),
                    PuntiRimanenti = table.Column<int>(type: "int", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anagrafica", x => x.IdAnagrafica);
                });

            migrationBuilder.CreateTable(
                name: "TipoViolazione",
                columns: table => new
                {
                    IdViolazione = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PuntiDecurtati = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoViolazione", x => x.IdViolazione);
                });

            migrationBuilder.CreateTable(
                name: "Statistiche",
                columns: table => new
                {
                    IdStatistiche = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAnagrafica = table.Column<int>(type: "int", nullable: false),
                    TotaleVerbali = table.Column<int>(type: "int", nullable: false),
                    TotalePuntiDecurtati = table.Column<int>(type: "int", nullable: false),
                    ImportoTotale = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistiche", x => x.IdStatistiche);
                    table.ForeignKey(
                        name: "FK_Statistiche_Anagrafica_IdAnagrafica",
                        column: x => x.IdAnagrafica,
                        principalTable: "Anagrafica",
                        principalColumn: "IdAnagrafica",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Verbale",
                columns: table => new
                {
                    IdVerbale = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAnagrafica = table.Column<int>(type: "int", nullable: false),
                    IdViolazione = table.Column<int>(type: "int", nullable: false),
                    DataViolazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndirizzoViolazione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nominativo_Agente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataTrascrizioneVerbale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DecurtamentoPunti = table.Column<int>(type: "int", nullable: true),
                    Cod_Fisc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoViolazioneIdViolazione = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbale", x => x.IdVerbale);
                    table.ForeignKey(
                        name: "FK_Verbale_Anagrafica_IdAnagrafica",
                        column: x => x.IdAnagrafica,
                        principalTable: "Anagrafica",
                        principalColumn: "IdAnagrafica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verbale_TipoViolazione_IdViolazione",
                        column: x => x.IdViolazione,
                        principalTable: "TipoViolazione",
                        principalColumn: "IdViolazione",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verbale_TipoViolazione_TipoViolazioneIdViolazione",
                        column: x => x.TipoViolazioneIdViolazione,
                        principalTable: "TipoViolazione",
                        principalColumn: "IdViolazione");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statistiche_IdAnagrafica",
                table: "Statistiche",
                column: "IdAnagrafica");

            migrationBuilder.CreateIndex(
                name: "IX_Verbale_IdAnagrafica",
                table: "Verbale",
                column: "IdAnagrafica");

            migrationBuilder.CreateIndex(
                name: "IX_Verbale_IdViolazione",
                table: "Verbale",
                column: "IdViolazione");

            migrationBuilder.CreateIndex(
                name: "IX_Verbale_TipoViolazioneIdViolazione",
                table: "Verbale",
                column: "TipoViolazioneIdViolazione");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistiche");

            migrationBuilder.DropTable(
                name: "Verbale");

            migrationBuilder.DropTable(
                name: "Anagrafica");

            migrationBuilder.DropTable(
                name: "TipoViolazione");
        }
    }
}
