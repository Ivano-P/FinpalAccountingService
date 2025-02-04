using FinpalAccountingService.Models;
using Microsoft.EntityFrameworkCore;
namespace FinpalAccountingService.Repositories;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; } 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Budget>()
            .Property(b => b.Montant)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Compte>()
            .Property(c => c.Solde)
            .HasPrecision(18, 2);

        modelBuilder.Entity<CompteAnnuel>()
            .Property(ca => ca.SoldeDebut)
            .HasPrecision(18, 2);
        
        modelBuilder.Entity<CompteAnnuel>()
            .Property(ca => ca.SoldeFin)
            .HasPrecision(18, 2);

        modelBuilder.Entity<CompteMensuel>()
            .Property(cm => cm.SoldeDebut)
            .HasPrecision(18, 2);

        modelBuilder.Entity<CompteMensuel>()
            .Property(cm => cm.SoldeFin)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Epargne>()
            .Property(e => e.Montant)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Facture>()
            .Property(f => f.Montant)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Facture>()
            .Property(f => f.TauxDePartage)
            .HasPrecision(5, 2);

        modelBuilder.Entity<Revenu>()
            .Property(r => r.Montant)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Transaction>()
            .Property(t => t.Montant)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Transaction>()
            .Property(t => t.TauxDePartage)
            .HasPrecision(5, 2);
    }
    
}