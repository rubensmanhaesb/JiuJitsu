using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class EnderecoPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                schema: "crm",
                table: "PessoaJuridica",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                schema: "crm",
                table: "PessoaJuridica",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                schema: "crm",
                table: "PessoaJuridica",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ibge",
                schema: "crm",
                table: "PessoaJuridica",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                schema: "crm",
                table: "PessoaJuridica",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                schema: "crm",
                table: "PessoaJuridica",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                schema: "crm",
                table: "PessoaJuridica",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                schema: "crm",
                table: "PessoaJuridica",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                schema: "crm",
                table: "PessoaJuridica");

            migrationBuilder.DropColumn(
                name: "Cep",
                schema: "crm",
                table: "PessoaJuridica");

            migrationBuilder.DropColumn(
                name: "Complemento",
                schema: "crm",
                table: "PessoaJuridica");

            migrationBuilder.DropColumn(
                name: "Ibge",
                schema: "crm",
                table: "PessoaJuridica");

            migrationBuilder.DropColumn(
                name: "Localidade",
                schema: "crm",
                table: "PessoaJuridica");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                schema: "crm",
                table: "PessoaJuridica");

            migrationBuilder.DropColumn(
                name: "Numero",
                schema: "crm",
                table: "PessoaJuridica");

            migrationBuilder.DropColumn(
                name: "Uf",
                schema: "crm",
                table: "PessoaJuridica");
        }
    }
}
