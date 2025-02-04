using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinpalAccountingService.Models;

public class User {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required] public string Nom { get; set; }
    [Required] public string Prenom { get; set; }
    [Required] public string Email { get; set; }
    public string MotDePasse { get; set; }
    
    public List<CompteAnnuel> ComptesAnnuels { get; set; } = new();
    public List<Compte> Comptes { get; set; } = new();

    [NotMapped] // Calculé dynamiquement
    public decimal Totale => Comptes.Sum(c => c.Solde);

}