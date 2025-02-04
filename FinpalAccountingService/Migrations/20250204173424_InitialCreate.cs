using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinpalAccountingService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MotDePasse = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Compte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Solde = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Partage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SharingUserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compte_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompteAnnuel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Annee = table.Column<int>(type: "int", nullable: false),
                    SoldeDebut = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SoldeFin = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompteAnnuel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompteAnnuel_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompteMensuel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Mois = table.Column<int>(type: "int", nullable: false),
                    SoldeDebut = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SoldeFin = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CompteAnnuelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompteMensuel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompteMensuel_CompteAnnuel_CompteAnnuelId",
                        column: x => x.CompteAnnuelId,
                        principalTable: "CompteAnnuel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CompteId = table.Column<int>(type: "int", nullable: false),
                    CompteMensuelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budget_CompteMensuel_CompteMensuelId",
                        column: x => x.CompteMensuelId,
                        principalTable: "CompteMensuel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Budget_Compte_CompteId",
                        column: x => x.CompteId,
                        principalTable: "Compte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Epargne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CompteDepotId = table.Column<int>(type: "int", nullable: false),
                    Frequence = table.Column<int>(type: "int", nullable: false),
                    CompteMensuelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epargne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Epargne_CompteMensuel_CompteMensuelId",
                        column: x => x.CompteMensuelId,
                        principalTable: "CompteMensuel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Epargne_Compte_CompteDepotId",
                        column: x => x.CompteDepotId,
                        principalTable: "Compte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Facture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    JourPrelevement = table.Column<int>(type: "int", nullable: false),
                    Frequence = table.Column<int>(type: "int", nullable: false),
                    Partage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TauxDePartage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    SharingUserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CompteId = table.Column<int>(type: "int", nullable: false),
                    CompteMensuelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facture_CompteMensuel_CompteMensuelId",
                        column: x => x.CompteMensuelId,
                        principalTable: "CompteMensuel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facture_Compte_CompteId",
                        column: x => x.CompteId,
                        principalTable: "Compte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Revenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Activite = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Periodicite = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CompteId = table.Column<int>(type: "int", nullable: false),
                    CompteMensuelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Revenu_CompteMensuel_CompteMensuelId",
                        column: x => x.CompteMensuelId,
                        principalTable: "CompteMensuel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Revenu_Compte_CompteId",
                        column: x => x.CompteId,
                        principalTable: "Compte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Tag = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SousType = table.Column<int>(type: "int", nullable: false),
                    Partage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TauxDePartage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    PersonnePartage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BudgetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_CompteId",
                table: "Budget",
                column: "CompteId");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_CompteMensuelId",
                table: "Budget",
                column: "CompteMensuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Compte_UserId",
                table: "Compte",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompteAnnuel_UserId",
                table: "CompteAnnuel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompteMensuel_CompteAnnuelId",
                table: "CompteMensuel",
                column: "CompteAnnuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Epargne_CompteDepotId",
                table: "Epargne",
                column: "CompteDepotId");

            migrationBuilder.CreateIndex(
                name: "IX_Epargne_CompteMensuelId",
                table: "Epargne",
                column: "CompteMensuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Facture_CompteId",
                table: "Facture",
                column: "CompteId");

            migrationBuilder.CreateIndex(
                name: "IX_Facture_CompteMensuelId",
                table: "Facture",
                column: "CompteMensuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Revenu_CompteId",
                table: "Revenu",
                column: "CompteId");

            migrationBuilder.CreateIndex(
                name: "IX_Revenu_CompteMensuelId",
                table: "Revenu",
                column: "CompteMensuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_BudgetId",
                table: "Transaction",
                column: "BudgetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Epargne");

            migrationBuilder.DropTable(
                name: "Facture");

            migrationBuilder.DropTable(
                name: "Revenu");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Budget");

            migrationBuilder.DropTable(
                name: "CompteMensuel");

            migrationBuilder.DropTable(
                name: "Compte");

            migrationBuilder.DropTable(
                name: "CompteAnnuel");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
