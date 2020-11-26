using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Revifast.Api.Migrations
{
    public partial class com : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PromocionId",
                table: "Servicio",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PagoAdelantado",
                columns: table => new
                {
                    PagoAdelantadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Procentaje = table.Column<decimal>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoAdelantado", x => x.PagoAdelantadoId);
                });

            migrationBuilder.CreateTable(
                name: "Promocion",
                columns: table => new
                {
                    PromocionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descuento = table.Column<decimal>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocion", x => x.PromocionId);
                });

            migrationBuilder.CreateTable(
                name: "ReservaEstado",
                columns: table => new
                {
                    ReservaEstadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaEstado", x => x.ReservaEstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ReservaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoId = table.Column<int>(nullable: false),
                    LocalId = table.Column<int>(nullable: false),
                    PagoAdelantadoId = table.Column<int>(nullable: false),
                    ReservaEstadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_Reserva_Local_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Local",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_PagoAdelantado_PagoAdelantadoId",
                        column: x => x.PagoAdelantadoId,
                        principalTable: "PagoAdelantado",
                        principalColumn: "PagoAdelantadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_ReservaEstado_ReservaEstadoId",
                        column: x => x.ReservaEstadoId,
                        principalTable: "ReservaEstado",
                        principalColumn: "ReservaEstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Vehiculo_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculo",
                        principalColumn: "VehiculoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservaDetalle",
                columns: table => new
                {
                    ReservaDetalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Hora = table.Column<TimeSpan>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    ReservaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaDetalle", x => x.ReservaDetalleId);
                    table.ForeignKey(
                        name: "FK_ReservaDetalle_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_PromocionId",
                table: "Servicio",
                column: "PromocionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_LocalId",
                table: "Reserva",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_PagoAdelantadoId",
                table: "Reserva",
                column: "PagoAdelantadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ReservaEstadoId",
                table: "Reserva",
                column: "ReservaEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_VehiculoId",
                table: "Reserva",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaDetalle_ReservaId",
                table: "ReservaDetalle",
                column: "ReservaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicio_Promocion_PromocionId",
                table: "Servicio",
                column: "PromocionId",
                principalTable: "Promocion",
                principalColumn: "PromocionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicio_Promocion_PromocionId",
                table: "Servicio");

            migrationBuilder.DropTable(
                name: "Promocion");

            migrationBuilder.DropTable(
                name: "ReservaDetalle");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "PagoAdelantado");

            migrationBuilder.DropTable(
                name: "ReservaEstado");

            migrationBuilder.DropIndex(
                name: "IX_Servicio_PromocionId",
                table: "Servicio");

            migrationBuilder.DropColumn(
                name: "PromocionId",
                table: "Servicio");
        }
    }
}
