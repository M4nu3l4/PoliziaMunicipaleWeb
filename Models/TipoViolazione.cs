using System.ComponentModel.DataAnnotations;


namespace Cops.Models
{
    public class TipoViolazione
    {
        [Key]
        public int IdViolazione { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Descrizione { get; set; }

        [Required]
        public decimal Importo { get; set; }

        [Required]
        public int PuntiDecurtati { get; set; }

        public virtual ICollection<Verbale>? Verbale { get; set; }
    }
}
