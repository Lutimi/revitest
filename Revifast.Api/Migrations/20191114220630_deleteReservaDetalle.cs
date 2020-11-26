using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Revifast.Api.Migrations
{
    public partial class deleteReservaDetalle : Migration
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

            migrationBuilder.DropTable(
                name: "ReservaDetalle");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "ReservaEstado",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Reserva",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Hora",
                table: "Reserva",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Reserva",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Promocion",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Promocion",
                unicode: false,
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "PagoAdelantado",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "PagoAdelantado",
                unicode: false,
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Categoria",
                unicode: false,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldUnicode: false,
                oldMaxLength: 2);

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

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "Hora",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Reserva");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "ReservaEstado",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Promocion",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Promocion",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "PagoAdelantado",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "PagoAdelantado",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Categoria",
                type: "varchar(2)",
                unicode: false,
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 10);

            migrationBuilder.CreateTable(
                name: "ReservaDetalle",
                columns: table => new
                {
                    ReservaDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservaId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_ReservaDetalle_ReservaId",
                table: "ReservaDetalle",
                column: "ReservaId",
                unique: true);

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
