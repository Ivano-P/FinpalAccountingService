using FinpalAccountingService.Models;
using Microsoft.EntityFrameworkCore;
namespace FinpalAccountingService.Repositories;

public class AppDbContext : DbContext {
    public DbSet<User> Users { get; set; }  // Equivalent to JpaRepository

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
}