using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Cops.Models
{
    public class Cittadino
    {
        [Key]  
        public int IdCittadino { get; set; }  

        public required string Cod_Fisc { get; set; }  

        public List<Verbale>? Verbali { get; set; } 
    }
}
