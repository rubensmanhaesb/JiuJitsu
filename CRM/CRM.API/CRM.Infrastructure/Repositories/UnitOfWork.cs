using CRM.Domain.Interfaces.Repositories;
using CRM.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RMB.Core.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Repositories
{
    public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {

        public UnitOfWork(IDbContextFactory<DataContext> contextFactory) : base(contextFactory.CreateDbContext()) { }




    }
}