using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cops.Models
{
    [Table("Anagrafica")]
    public class Anagrafica
    {
        [Key]

        public int IdAnagrafica { get; set; }
        [Required]
        public string Cognome { get; set; } = string.Empty;
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public string Indirizzo { get; set; } = string.Empty;
        [Required]
        public string Citta { get; set; } = string.Empty;
       
        [Required]
        public string? CAP { get; set; }
        [Required]
        [Column("Cod_Fisc")]
        public string Cod_Fisc { get; set; } = string.Empty;
        public int PuntiDecurtati { get; set; }
        public int PuntiRimanenti { get; set; }
       
        public required string Descrizione { get; set; }
        public ICollection<Verbale> Verbali { get; set; } = new List<Verbale>();
    }
}


