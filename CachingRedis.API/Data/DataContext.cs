using CachingRedis.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CachingRedis.API.Data;

/// <summary>
/// Information of data context
/// CreatedBy: ThiepTT(26/10/2023)
/// </summary>
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    /// <summary>
    /// Users
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// On model creating
    /// </summary>
    /// <param name="modelBuilder">ModelBuilder</param>
    /// CreatedBy: ThiepTT(26/10/2023)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(user => user.UserId);
    }
}