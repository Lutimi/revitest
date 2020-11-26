using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Revifast.Api.Migrations
{
    public partial class gusz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 2, nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Conductor",
                columns: table => new
                {
                    ConductorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Dni = table.Column<string>(unicode: false, maxLength: 8, nullable: false),
                    Direccion = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    Celular = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Correo = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductor", x => x.ConductorId);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    MarcaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.MarcaId);
                });

            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    ModeloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    MarcaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.ModeloId);
                    table.ForeignKey(
                        name: "Modelo_Marca",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "MarcaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    VehiculoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Color = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    FechaFabricacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    ConductorId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    ModeloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.VehiculoId);
                    table.ForeignKey(
                        name: "Vehiculo_Categoria",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Vehiculo_Conductor",
                        column: x => x.ConductorId,
                        principalTable: "Conductor",
                        principalColumn: "ConductorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Vehiculo_Modelo",
                        column: x => x.ModeloId,
                        principalTable: "Modelo",
                        principalColumn: "ModeloId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_MarcaId",
                table: "Modelo",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_CategoriaId",
                table: "Vehiculo",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_ConductorId",
                table: "Vehiculo",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_ModeloId",
                table: "Vehiculo",
                column: "ModeloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Conductor");

            migrationBuilder.DropTable(
                name: "Modelo");

            migrationBuilder.DropTable(
                name: "Marca");
        }
    }
}
