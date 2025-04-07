using CRM.Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Validations.PessoaJuridica
{
    public class PessoaJuridicaUpdateValidation : PessoaJuridicaBaseValidation
    {
        public PessoaJuridicaUpdateValidation(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            ConfigureRules();
        }

        private void ConfigureRules()
        {
            ValidateRazaoSocial();
            ValidateNomeFantasia();
            ValidateEmail();
            ValidateCNPJ();
            ValidateId();
            ValidateIdIsUnique();
            ValidateEndereco();

        }
    }
}
