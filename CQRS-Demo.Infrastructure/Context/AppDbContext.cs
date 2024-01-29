using CQRS_Demo.Domain.Entities;
using CQRS_Demo.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MemberConfiguration());
    }
}
