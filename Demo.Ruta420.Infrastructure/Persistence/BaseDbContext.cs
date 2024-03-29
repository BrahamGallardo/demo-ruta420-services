﻿using Demo.Ruta420.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Demo.Ruta420.Infrastructure.Persistence
{
    public abstract class BaseDbContext : DbContext
    {
        private IHttpContextAccessor _context;

        public BaseDbContext(DbContextOptions options
            , IHttpContextAccessor context) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context = context;
        }

        private string? GetCurrentUserId()
        {
            return _context?.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.CreatedBy = GetCurrentUserId();
                        entry.Entity.Activated = true;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
