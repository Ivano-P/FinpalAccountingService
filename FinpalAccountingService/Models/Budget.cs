using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace FinpalAccountingService.Models;

public class Budget {
    [Key]
    public int Id { get; set; }
    [Required] public string Nom { get; set; }
    [Required] public decimal Montant { get; set; }
    
    public List<Transaction> Transactions { get; set; } = new();

    // Clé étrangère vers compte
    public int CompteId { get; set; }
    public Compte Compte { get; set; }

    [NotMapped] // Calculé
    public decimal Rest => Montant - Transactions.Sum(t => t.Montant);
}