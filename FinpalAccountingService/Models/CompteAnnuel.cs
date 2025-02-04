using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinpalAccountingService.Models;

public class CompteAnnuel {
    [Key]
    public int Id { get; set; }
    public int Annee { get; set; }
    public decimal SoldeDebut { get; set; }
    public decimal SoldeFin { get; set; }
    public List<CompteMensuel> ComptesMensuels { get; set; } = new();
    
    // Clé étrangère vers Utilisateur
    public Guid UtilisateurId { get; set; }
    public User User { get; set; }  // Navigation property
    
    [NotMapped] // Calculé dynamiquement
    public decimal RevenusAnnuel { get; set; }
    
    [NotMapped] // Calculé dynamiquement
    public decimal DépensesAnnuel { get; set; }
}