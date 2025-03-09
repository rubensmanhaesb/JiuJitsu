using CRM.Application.Dtos.PessoaJuridica;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Commands
{
    public class PessoaJuridicaUpdateCommand : PessoaJuridicaCommand, IRequest<PessoaJuridicaDto>
    {

        [MinLength(2, ErrorMessage = "Razão Social deve ter no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Razão Social deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Razão Social é obrigatório.")]
        public string? RazaoSocial { get; set; }

        [MinLength(2, ErrorMessage = "Nome Fantasia deve ter no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Nome Fantasia deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Nome Fantasia é obrigatório.")]
        public string? NomeFantasia { get; set; }

        [Required(ErrorMessage = "CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$",
            ErrorMessage = "CNPJ deve estar no formato XX.XXX.XXX/XXXX-XX")]
        public string? Cnpj { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string? email { get; set; }

    }
}
