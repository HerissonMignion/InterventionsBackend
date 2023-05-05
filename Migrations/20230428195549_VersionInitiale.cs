using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterventionsBackend.Migrations
{
    public partial class VersionInitiale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Problemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dateProbleme = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    prenom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    noTypeProbleme = table.Column<int>(type: "int", nullable: false),
                    courriel = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    courrielConfirmation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telephone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    notification = table.Column<int>(type: "int", nullable: false),
                    noUnite = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descriptionProbleme = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problemes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypesProbleme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesProbleme", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TypesProbleme",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Problème d'écran" },
                    { 2, "Problème avec le disque dur" },
                    { 3, "Problème de connexion réseau" },
                    { 4, "Problème avec la souris" },
                    { 5, "Problème de clavier" },
                    { 6, "Problème d'ouverture du logiciel Ms-Word" },
                    { 7, "Problème d'ouverture du logiciel Ms-Excel" },
                    { 8, "Problème d'imprimante" },
                    { 9, "Problème entre la chaise et le clavier..." },
                    { 10, "Autre" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Problemes");

            migrationBuilder.DropTable(
                name: "TypesProbleme");
        }
    }
}
