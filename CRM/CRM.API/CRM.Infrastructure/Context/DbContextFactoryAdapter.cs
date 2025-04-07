using Microsoft.EntityFrameworkCore;


namespace CRM.Infrastructure.Data.Context
{
    /// <summary>
    /// Adapter that allows using IDbContextFactory<DataContext> as IDbContextFactory<DbContext>.
    /// Useful when a generic DbContext factory is required in layers that should not depend on a specific context type.
    /// </summary>
    public class DbContextFactoryAdapter : IDbContextFactory<DbContext>
    {
        private readonly IDbContextFactory<DataContext> _inner;

        /// <summary>
        /// Initializes a new instance of the adapter with the concrete DataContext factory.
        /// </summary>
        /// <param name="inner">The underlying factory for DataContext.</param>
        public DbContextFactoryAdapter(IDbContextFactory<DataContext> inner)
        {
            _inner = inner;
        }

        /// <summary>
        /// Creates a new instance of DbContext by calling the inner factory.
        /// </summary>
        /// <returns>A new instance of DbContext.</returns>
        public DbContext CreateDbContext()
        {
            return _inner.CreateDbContext();
        }

        /// <summary>
        /// Asynchronously creates a new instance of DbContext by calling the inner factory.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation, containing the new DbContext instance.</returns>
        public async Task<DbContext> CreateDbContextAsync(CancellationToken cancellationToken = default)
        {
            return await _inner.CreateDbContextAsync(cancellationToken);
        }
    }
}
