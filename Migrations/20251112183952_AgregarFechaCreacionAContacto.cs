using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiPAM3.Migrations
{
    /// <inheritdoc />
    public partial class AgregarFechaCreacionAContacto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
migrationBuilder.AddColumn<DateTime>(
        name: "FechaCreacion",
        table: "Contacto",
        type: "datetime2",
        nullable: false,
        defaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
migrationBuilder.DropColumn(
        name: "FechaCreacion",
        table: "Contacto");
        }
    }
}
