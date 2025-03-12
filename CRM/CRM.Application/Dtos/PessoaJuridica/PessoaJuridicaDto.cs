
namespace CRM.Application.Dtos.PessoaJuridica
{
    public class PessoaJuridicaDto : PessoaDto
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
    }
}
