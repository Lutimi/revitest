using Microsoft.EntityFrameworkCore.Migrations;

namespace Revifast.Api.Migrations
{
    public partial class aiudaHillary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Local_LocalId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_PagoAdelantado_PagoAdelantadoId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_ReservaEstado_ReservaEstadoId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Vehiculo_VehiculoId",
                table: "Reserva");

            migrationBuilder.AddForeignKey(
                name: "Reserva_Local",
                table: "Reserva",
                column: "LocalId",
                principalTable: "Local",
                principalColumn: "LocalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Reserva_PagoAdelantado",
                table: "Reserva",
                column: "PagoAdelantadoId",
                principalTable: "PagoAdelantado",
                principalColumn: "PagoAdelantadoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Reserva_ReservaEstado",
                table: "Reserva",
                column: "ReservaEstadoId",
                principalTable: "ReservaEstado",
                principalColumn: "ReservaEstadoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Reserva_Vehiculo",
                table: "Reserva",
                column: "VehiculoId",
                principalTable: "Vehiculo",
                principalColumn: "VehiculoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Reserva_Local",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "Reserva_PagoAdelantado",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "Reserva_ReservaEstado",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "Reserva_Vehiculo",
                table: "Reserva");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Local_LocalId",
                table: "Reserva",
                column: "LocalId",
                principalTable: "Local",
                principalColumn: "LocalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_PagoAdelantado_PagoAdelantadoId",
                table: "Reserva",
                column: "PagoAdelantadoId",
                principalTable: "PagoAdelantado",
                principalColumn: "PagoAdelantadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_ReservaEstado_ReservaEstadoId",
                table: "Reserva",
                column: "ReservaEstadoId",
                principalTable: "ReservaEstado",
                principalColumn: "ReservaEstadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Vehiculo_VehiculoId",
                table: "Reserva",
                column: "VehiculoId",
                principalTable: "Vehiculo",
                principalColumn: "VehiculoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
