using System.ComponentModel.DataAnnotations;

namespace FinpalAccountingService.Models;

public class Compte {
    [Key]
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Numero { get; set; }
    public decimal Solde { get; set; }
    // Clé étrangère vers Utilisateur
    public Guid UserId { get; set; }
    public User User { get; set; }  // Navigation property
    public bool Partage { get; set; }
    public Guid SharingUserId { get; set; }
}