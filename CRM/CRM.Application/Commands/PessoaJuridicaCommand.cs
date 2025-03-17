using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Commands
{
    public class PessoaJuridicaCommand  
    {
        [Required(ErrorMessage = "Informe o id da Pessoa Jurídica.")]
        public Guid? Id { get; set; }
    }
}
