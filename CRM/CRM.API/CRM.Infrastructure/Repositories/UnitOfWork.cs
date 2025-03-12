using CRM.Domain.Interfaces.Repositories;
using CRM.Infrastructure.Data.Context;
using CRM.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RMB.Core.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Repositories
{
    public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        private readonly DataContext _datacontext;
        public UnitOfWork(IDbContextFactory<DataContext> contextFactory) : this(contextFactory.CreateDbContext()) { }

        private UnitOfWork(DataContext context) : base(context) {
            _datacontext = context;
        }

        public IPessoaJuridicaRepository? PessoaJuridicaRepository => new PessoaJuridicaRepository(_datacontext);
    }
}