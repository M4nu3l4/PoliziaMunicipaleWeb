


namespace Cops.Models.ViewModels
{
    public class VerbaleViewModel
    {
        public int IdVerbale { get; set; }
        public int IdAnagrafica { get; set; }

        public int IdViolazione { get; set; }
        public DateTime DataViolazione { get; set; }
        public required string IndirizzoViolazione { get; set; }
        public string? Nominativo_Agente { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }

        public decimal? Importo { get; set; }
        public int? DecurtamentoPunti { get; set; }     

        public required string Cod_Fisc { get; set; }
    }
}