using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cops.Models
{
    [Table("Verbale")]
    public class Verbale
    {
        [Key]
        public int IdVerbale { get; set; }

        
        [ForeignKey("Anagrafica")]
        public int IdAnagrafica { get; set; }

        [ForeignKey("TipoViolazione")]
        public int IdViolazione { get; set; }

        public DateTime DataViolazione { get; set; }

        public required string IndirizzoViolazione { get; set; }

        public string? Nominativo_Agente { get; set; }

        public DateTime DataTrascrizioneVerbale { get; set; }

        public decimal? Importo { get; set; }
        public int? DecurtamentoPunti { get; set; }

        [Required]
        [Column("Cod_Fisc")]
        public string Cod_Fisc { get; set; } = string.Empty;

        public required virtual Anagrafica Anagrafica { get; set; }
        public required virtual TipoViolazione TipoViolazione { get; set; }
    }
}
