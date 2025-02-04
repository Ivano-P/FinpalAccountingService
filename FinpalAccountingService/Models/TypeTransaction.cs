namespace FinpalAccountingService.Models{
    
    public enum TypeTransaction
    {
        ENTREE,
        SORTIE
    }

    public enum SousTypeTransaction
    {
        VIR, // Virement
        CB,  // Carte bancaire
        PRELEVEMENT
    }

    public enum FrequencePrelevement
    {
        UNIQUE,
        MENSUELLE,
        TRIMESTRIELLE,
        ANNUELLE
    }

    public enum PeriodeRevenu
    {
        UNIQUE,
        MENSUELLE,
        TRIMESTRIELLE,
        ANNUELLE
    }
    
}