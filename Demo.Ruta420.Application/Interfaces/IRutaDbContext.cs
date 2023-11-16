using Demo.Ruta420.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Ruta420.Application.Interfaces
{
    public interface IRutaDbContext
    {
        DbSet<Role> Roles { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Session> Sessions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
