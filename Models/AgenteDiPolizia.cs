using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cops.Models
{
    public class AgenteDiPolizia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Cognome { get; set; }= string.Empty;


        [Required]
        [Column("Cod_Fisc")]

        public string Cod_Fisc { get; set; } = string.Empty;

        

        public required List<Verbale> Verbali { get; set; }

        public required virtual Anagrafica Anagrafica { get; set; }
        public required virtual TipoViolazione TipoViolazione { get; set; }
        public required virtual Statistiche Statistiche { get; set; }
    }
}

