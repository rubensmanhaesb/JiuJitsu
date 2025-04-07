using CRM.Domain.Interfaces.Repositories;
using CRM.Infrastructure.Data.Context;
using CRM.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RMB.Core.Repositories.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Repositories
{
    public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        private readonly IDbContextFactory<DbContext> _contextFactory;

        public UnitOfWork(IDbContextFactory<DbContext> factory) : base(factory) 
        {
            _contextFactory= factory;
        }


        public IPessoaJuridicaRepository? PessoaJuridicaRepository => new PessoaJuridicaRepository(_contextFactory);
    }
}