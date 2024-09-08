using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaData.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Afiliado",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    RifaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afiliado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rifador",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rifador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rifa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Premio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSorteio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorBilhete = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    RifadorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rifa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rifa_Rifador_RifadorId",
                        column: x => x.RifadorId,
                        principalTable: "Rifador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Bilhete",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RifaId = table.Column<long>(type: "bigint", nullable: false),
                    AfiliadoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilhete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bilhete_Afiliado_AfiliadoId",
                        column: x => x.AfiliadoId,
                        principalTable: "Afiliado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Bilhete_Rifa_RifaId",
                        column: x => x.RifaId,
                        principalTable: "Rifa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilhete_AfiliadoId",
                table: "Bilhete",
                column: "AfiliadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilhete_RifaId",
                table: "Bilhete",
                column: "RifaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rifa_RifadorId",
                table: "Rifa",
                column: "RifadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilhete");

            migrationBuilder.DropTable(
                name: "Afiliado");

            migrationBuilder.DropTable(
                name: "Rifa");

            migrationBuilder.DropTable(
                name: "Rifador");
        }
    }
}
