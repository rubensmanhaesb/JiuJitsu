using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Commands
{
    public class EnderecoCommand
    {
        [Required(ErrorMessage = "CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP deve estar no formato 00000-000.")]
        public string? Cep { get; set; }

        [Required(ErrorMessage = "Logradouro é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Logradouro deve ter no máximo {1} caracteres.")]
        public string? Logradouro { get; set; }

        [Required(ErrorMessage = "Número é obrigatório.")]
        [MaxLength(20, ErrorMessage = "Número deve ter no máximo {1} caracteres.")]
        public string? Numero { get; set; }

        [MaxLength(100, ErrorMessage = "Complemento deve ter no máximo {1} caracteres.")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório.")]
        [MaxLength(60, ErrorMessage = "Bairro deve ter no máximo {1} caracteres.")]
        public string? Bairro { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatória.")]
        [MaxLength(60, ErrorMessage = "Cidade deve ter no máximo {1} caracteres.")]
        public string? Localidade { get; set; }

        [Required(ErrorMessage = "UF é obrigatória.")]
        [StringLength(2, ErrorMessage = "UF deve ter exatamente {1} caracteres.")]
        public string? Uf { get; set; }

        [MaxLength(10, ErrorMessage = "IBGE deve ter no máximo {1} caracteres.")]
        public string? Ibge { get; set; }
    }

}
