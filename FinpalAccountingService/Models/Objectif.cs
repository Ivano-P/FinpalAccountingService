using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinpalAccountingService.Models;

public class Objectif {
    [Key] public int Id { get; set; }

    [Required] public string Nom { get; set; }

    [Required] public decimal MontantCible { get; set; }

    // Liste des comptes de dépôt associés
    public List<Compte> ComptesDepot { get; set; } = new();

    // Propriété calculée (non stockée en base) pour MontantActuel
    [NotMapped] public decimal MontantActuel => ComptesDepot.Sum(c => c.Solde);

    // Propriété calculée (non stockée en base) pour le taux d'achèvement
    [NotMapped] public decimal TauxAchevement => MontantCible > 0 ? (MontantActuel / MontantCible) * 100 : 0;
}



