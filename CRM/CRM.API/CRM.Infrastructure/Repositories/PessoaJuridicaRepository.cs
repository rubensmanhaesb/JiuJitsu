using CRM.Domain.Entities;
using CRM.Domain.Interfaces.Repositories;
using CRM.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using RMB.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Data.Repositories
{
    public class PessoaJuridicaRepository : 
        BaseRepository<PessoaJuridica>,
        IPessoaJuridicaRepository
    {
        public PessoaJuridicaRepository(DbContext context) : base(context)
        {
        }


    }
}
