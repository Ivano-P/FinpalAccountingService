using System.ComponentModel.DataAnnotations;

namespace FinpalAccountingService.Models;

public class Compte {
    [Key]
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Numero { get; set; }
    public decimal Solde { get; set; }
    public bool Partage { get; set; }
    public string? PersonnePartage { get; set; }
}