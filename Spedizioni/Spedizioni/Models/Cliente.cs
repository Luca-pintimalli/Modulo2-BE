using System;
using System.ComponentModel.DataAnnotations;

namespace Spedizioni.Models
{
	public class Cliente
	{
       
            public int Id { get; set; }

            [Required]
            public string Nome { get; set; }

            public string CodiceFiscale { get; set; }

            public string PartitaIVA { get; set; }

            [Required]
            public string TipoCliente { get; set; } // Privato o Azienda

          

        
    }
}

