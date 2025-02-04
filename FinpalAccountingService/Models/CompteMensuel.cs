using System.ComponentModel.DataAnnotations;

namespace FinpalAccountingService.Models;

public class CompteMensuel {
    [Key]
    public int Id { get; set; }
    public int Mois { get; set; }
    public decimal SoldeDebut { get; set; }
    public decimal SoldeFin { get; set; }
    public List<Revenu> Revenus { get; set; } = new();
    public List<Facture> Factures { get; set; } = new();
    public List<Epargne> Epargnes { get; set; } = new();
    public List<Budget> Budgets { get; set; } = new();
    
    // Clé étrangère vers CompteAnnuel
    public int CompteAnnuelId { get; set; }
    public CompteAnnuel CompteAnnuel { get; set; } // Navigation property
    
}