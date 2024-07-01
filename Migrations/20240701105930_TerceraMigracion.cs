using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S.I_AgenciaViajes.Migrations
{
    /// <inheritdoc />
    public partial class TerceraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreTurista",
                table: "Reservas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NroReserva",
                table: "Reservas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreTurista",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "NroReserva",
                table: "Reservas");
        }
    }
}
