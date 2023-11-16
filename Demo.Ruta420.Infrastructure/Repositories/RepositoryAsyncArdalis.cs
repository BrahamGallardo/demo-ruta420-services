using Ardalis.Specification.EntityFrameworkCore;
using Demo.Ruta420.Application.Interfaces;
using Demo.Ruta420.Infrastructure.Persistence;

namespace Demo.Ruta420.Infrastructure.Repositories
{
    public class RepositoryAsyncArdalis<T>: RepositoryBase<T>, IRepositoryAsyncArdalis<T> where T : class
    {
        private readonly RutaDbContext _dbContext;
        public RepositoryAsyncArdalis(RutaDbContext dbContext) : base(dbContext) => _dbContext = dbContext;
    }
}
