using CRM.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
