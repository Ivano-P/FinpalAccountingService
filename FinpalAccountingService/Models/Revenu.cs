using System.ComponentModel.DataAnnotations;

namespace FinpalAccountingService.Models;

public class Revenu {
    [Key] public int Id { get; set; }
    [Required] public string Activite { get; set; }
    [Required] public decimal Montant { get; set; }
    public PeriodeRevenu Periodicite { get; set; }
    public DateTime Date { get; set; }
    
    public int CompteId { get; set; }
    public Compte CompteDeDepot { get; set; }
}