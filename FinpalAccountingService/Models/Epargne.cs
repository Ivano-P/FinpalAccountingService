using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinpalAccountingService.Models;

public class Epargne {
    [Key] public int Id { get; set; }
    public string Nom { get; set; }
    public decimal Montant { get; set; }
    public Compte CompteDepot { get; set; }
    public FrequencePrelevement Frequence { get; set; }
    
    [NotMapped] // Calculé dynamiquement
    public decimal Taux { get; set; }
}