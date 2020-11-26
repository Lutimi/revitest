using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Revifast.Api.Migrations
{
    public partial class empHorLocSer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Distrito_Provincia",
                table: "Distrito");

            migrationBuilder.DropForeignKey(
                name: "Provincia_Departamento",
                table: "Provincia");

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Ruc = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Telefono = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Correo = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    HorarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraApertura = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraCierre = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.HorarioId);
                });

            migrationBuilder.CreateTable(
                name: "Local",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    HorarioId = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: false),
                    DistritoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Local", x => x.LocalId);
                    table.ForeignKey(
                        name: "Local_Distrito",
                        column: x => x.DistritoId,
                        principalTable: "Distrito",
                        principalColumn: "DistritoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Local_Empresa",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Local_Horario",
                        column: x => x.HorarioId,
                        principalTable: "Horario",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    ServicioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    LocalId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.ServicioId);
                    table.ForeignKey(
                        name: "Servicio_Categoria",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Servicio_Local",
                        column: x => x.LocalId,
                        principalTable: "Local",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Local_DistritoId",
                table: "Local",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Local_EmpresaId",
                table: "Local",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Local_HorarioId",
                table: "Local",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_CategoriaId",
                table: "Servicio",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_LocalId",
                table: "Servicio",
                column: "LocalId");

            migrationBuilder.AddForeignKey(
                name: "Distrito_Provincia",
                table: "Distrito",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "ProvinciaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Provincia_Departamento",
                table: "Provincia",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Distrito_Provincia",
                table: "Distrito");

            migrationBuilder.DropForeignKey(
                name: "Provincia_Departamento",
                table: "Provincia");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Local");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.AddForeignKey(
                name: "Distrito_Provincia",
                table: "Distrito",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "ProvinciaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Provincia_Departamento",
                table: "Provincia",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
