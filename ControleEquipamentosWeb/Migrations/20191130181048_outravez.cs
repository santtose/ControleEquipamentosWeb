using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEquipamentosWeb.Migrations
{
    public partial class outravez : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipamentoId",
                table: "Emprestimos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_EquipamentoId",
                table: "Emprestimos",
                column: "EquipamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimos_Equipamentos_EquipamentoId",
                table: "Emprestimos",
                column: "EquipamentoId",
                principalTable: "Equipamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_Equipamentos_EquipamentoId",
                table: "Emprestimos");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimos_EquipamentoId",
                table: "Emprestimos");

            migrationBuilder.DropColumn(
                name: "EquipamentoId",
                table: "Emprestimos");
        }
    }
}
