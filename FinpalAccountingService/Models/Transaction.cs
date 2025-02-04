using System.ComponentModel.DataAnnotations;

namespace FinpalAccountingService.Models;

public class Transaction {
    [Key] public int Id { get; set; }
    [Required] public string Nom { get; set; }
    [Required] public decimal Montant { get; set; }
    public string Tag { get; set; }
    [Required] public TypeTransaction Type { get; set; } // Entrée - Sortie
    public SousTypeTransaction SousType { get; set; } // Vir, CB, prélèvement
    public bool Partage { get; set; }
    public decimal? TauxDePartage { get; set; }
    public string? PersonnePartage { get; set; } // Email

    public int BudgetId { get; set; }
    public Budget Budget { get; set; }
}