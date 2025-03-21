using CRM.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Validation.PessoaJuridica
{
    public class PessoaJuridicaDeleteValidation : PessoaJuridicaBaseValidation
    {

        public PessoaJuridicaDeleteValidation(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            ConfigureRules();
        }

        private void ConfigureRules()
        {
            ValidateId();
            ValidateIdIsUnique();

        }
    }
}