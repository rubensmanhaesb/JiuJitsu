using CRM.Domain.Interfaces.Repositories;


namespace CRM.Domain.Validation.PessoaJuridica
{
    public class PessoaJuridicaAddValidation : PessoaJuridicaBaseValidation
    {
        public PessoaJuridicaAddValidation(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            ConfigureRules();
        }

        private void ConfigureRules()
        {
            ValidateId();
            ValidateRazaoSocial();
            ValidateNomeFantasia();
            ValidateEmail();
            ValidateCNPJ();
            ValidateId();

        }
    }
}
