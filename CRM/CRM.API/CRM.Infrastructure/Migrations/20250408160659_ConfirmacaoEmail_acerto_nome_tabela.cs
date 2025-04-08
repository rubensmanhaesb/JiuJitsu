using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfirmacaoEmail_acerto_nome_tabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmacoesEmail_PessoaJuridica_PessoaId",
                schema: "crm",
                table: "ConfirmacoesEmail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfirmacoesEmail",
                schema: "crm",
                table: "ConfirmacoesEmail");

            migrationBuilder.RenameTable(
                name: "ConfirmacoesEmail",
                schema: "crm",
                newName: "ConfirmacaoEmail",
                newSchema: "crm");

            migrationBuilder.RenameIndex(
                name: "IX_ConfirmacoesEmail_Token",
                schema: "crm",
                table: "ConfirmacaoEmail",
                newName: "IX_ConfirmacaoEmail_Token");

            migrationBuilder.RenameIndex(
                name: "IX_ConfirmacoesEmail_PessoaId",
                schema: "crm",
                table: "ConfirmacaoEmail",
                newName: "IX_ConfirmacaoEmail_PessoaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfirmacaoEmail",
                schema: "crm",
                table: "ConfirmacaoEmail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmacaoEmail_PessoaJuridica_PessoaId",
                schema: "crm",
                table: "ConfirmacaoEmail",
                column: "PessoaId",
                principalSchema: "crm",
                principalTable: "PessoaJuridica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmacaoEmail_PessoaJuridica_PessoaId",
                schema: "crm",
                table: "ConfirmacaoEmail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfirmacaoEmail",
                schema: "crm",
                table: "ConfirmacaoEmail");

            migrationBuilder.RenameTable(
                name: "ConfirmacaoEmail",
                schema: "crm",
                newName: "ConfirmacoesEmail",
                newSchema: "crm");

            migrationBuilder.RenameIndex(
                name: "IX_ConfirmacaoEmail_Token",
                schema: "crm",
                table: "ConfirmacoesEmail",
                newName: "IX_ConfirmacoesEmail_Token");

            migrationBuilder.RenameIndex(
                name: "IX_ConfirmacaoEmail_PessoaId",
                schema: "crm",
                table: "ConfirmacoesEmail",
                newName: "IX_ConfirmacoesEmail_PessoaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfirmacoesEmail",
                schema: "crm",
                table: "ConfirmacoesEmail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmacoesEmail_PessoaJuridica_PessoaId",
                schema: "crm",
                table: "ConfirmacoesEmail",
                column: "PessoaId",
                principalSchema: "crm",
                principalTable: "PessoaJuridica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
