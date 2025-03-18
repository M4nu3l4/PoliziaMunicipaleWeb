
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cops.Models
{
    public class Statistiche
    {
        [Key]
        public int IdStatistiche { get; set; }

        [Required]
        public int IdAnagrafica { get; set; }

        [ForeignKey("IdAnagrafica")]
        public required Anagrafica Anagrafica { get; set; }

        public int TotaleVerbali { get; set; }

        public int TotalePuntiDecurtati { get; set; }

        public decimal ImportoTotale { get; set; }
    }
}
