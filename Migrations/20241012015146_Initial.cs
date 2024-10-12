using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FrailynGarcia_Ap1_p1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deudores",
                columns: table => new
                {
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deudores", x => x.DeudorId);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamosId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deudores = table.Column<string>(type: "TEXT", nullable: false),
                    Conceptos = table.Column<string>(type: "TEXT", nullable: true),
                    Montos = table.Column<int>(type: "INTEGER", nullable: false),
                    Balance = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamosId);
                });

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Monto = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.CobroId);
                    table.ForeignKey(
                        name: "FK_Cobros_Deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "Deudores",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CobroDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorCobrado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobroDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_CobroDetalle_Cobros_CobroId",
                        column: x => x.CobroId,
                        principalTable: "Cobros",
                        principalColumn: "CobroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CobroDetalle_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Deudores",
                columns: new[] { "DeudorId", "Nombres" },
                values: new object[,]
                {
                    { 1, "Frailyn" },
                    { 2, "Celainy" },
                    { 3, "Abel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CobroDetalle_CobroId",
                table: "CobroDetalle",
                column: "CobroId");

            migrationBuilder.CreateIndex(
                name: "IX_CobroDetalle_PrestamoId",
                table: "CobroDetalle",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobros_DeudorId",
                table: "Cobros",
                column: "DeudorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CobroDetalle");

            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Deudores");
        }
    }
}
