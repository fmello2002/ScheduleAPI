using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoSolicitacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Solicitacoes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Solicitacoes");
        }
    }
}
