using EsleyterEduardoBA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EsleyterEduardoBA.Infrastructure.Context;

public class SistemaTicketsDbContext : DbContext
{
    public SistemaTicketsDbContext(DbContextOptions<SistemaTicketsDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Response> Responses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity("UserRoles");

        base.OnModelCreating(modelBuilder);
    }
}