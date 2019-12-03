using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEquipamentosWeb.Migrations
{
    public partial class AlteracaoOcorrencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Devolvido",
                table: "Ocorrencias",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Devolvido",
                table: "Ocorrencias");
        }
    }
}
