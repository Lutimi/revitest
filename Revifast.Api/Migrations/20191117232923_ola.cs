using Microsoft.EntityFrameworkCore.Migrations;

namespace Revifast.Api.Migrations
{
    public partial class ola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Servicio_Promocion_PromocionId",
                table: "Servicio");

            migrationBuilder.DropIndex(
                name: "IX_Servicio_PromocionId",
                table: "Servicio");

            migrationBuilder.DropColumn(
                name: "PromocionId",
                table: "Servicio");

            migrationBuilder.AddColumn<int>(
                name: "ServicioId",
                table: "Promocion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Dia",
                table: "Horario",
                unicode: false,
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Feriado",
                table: "Horario",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Promocion_ServicioId",
                table: "Promocion",
                column: "ServicioId");

            migrationBuilder.AddForeignKey(
                name: "Servicio_Promocion",
                table: "Promocion",
                column: "ServicioId",
                principalTable: "Servicio",
                principalColumn: "ServicioId",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Servicio_Promocion",
                table: "Promocion");

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

            migrationBuilder.DropIndex(
                name: "IX_Promocion_ServicioId",
                table: "Promocion");

            migrationBuilder.DropColumn(
                name: "ServicioId",
                table: "Promocion");

            migrationBuilder.DropColumn(
                name: "Dia",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "Feriado",
                table: "Horario");

            migrationBuilder.AddColumn<int>(
                name: "PromocionId",
                table: "Servicio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_PromocionId",
                table: "Servicio",
                column: "PromocionId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Servicio_Promocion_PromocionId",
                table: "Servicio",
                column: "PromocionId",
                principalTable: "Promocion",
                principalColumn: "PromocionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
