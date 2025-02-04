using System.ComponentModel.DataAnnotations;

namespace FinpalAccountingService.Models;

public class Facture {
    [Key] public int Id { get; set; }
    [Required] public string Nom { get; set; }
    [Required] public decimal Montant { get; set; }
    public int JourPrelevement { get; set; }
    public FrequencePrelevement Frequence { get; set; }
    public bool Partage { get; set; }
    public decimal? TauxDePartage { get; set; }
    public string? PersonnePartage { get; set; }

    public int CompteId { get; set; }
    public Compte CompteDePrelevement { get; set; }
}