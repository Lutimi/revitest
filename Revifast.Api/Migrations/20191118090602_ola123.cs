using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Revifast.Api.Migrations
{
    public partial class ola123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Hora",
                table: "Reserva",
                unicode: false,
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "Fecha",
                table: "Reserva",
                unicode: false,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "HoraCierre",
                table: "Horario",
                unicode: false,
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "HoraApertura",
                table: "Horario",
                unicode: false,
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<bool>(
                name: "Feriado",
                table: "Horario",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Dia",
                table: "Horario",
                unicode: false,
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldUnicode: false,
                oldMaxLength: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Hora",
                table: "Reserva",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Reserva",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HoraCierre",
                table: "Horario",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HoraApertura",
                table: "Horario",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Feriado",
                table: "Horario",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Dia",
                table: "Horario",
                type: "varchar(11)",
                unicode: false,
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 11,
                oldNullable: true);
        }
    }
}
