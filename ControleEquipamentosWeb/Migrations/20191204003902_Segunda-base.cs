using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEquipamentosWeb.Migrations
{
    public partial class Segundabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Pessoas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Pessoas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Pessoas");
        }
    }
}
