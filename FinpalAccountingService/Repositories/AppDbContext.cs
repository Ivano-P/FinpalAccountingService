using FinpalAccountingService.Models;
using Microsoft.EntityFrameworkCore;
namespace FinpalAccountingService.Repositories;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; } 
}