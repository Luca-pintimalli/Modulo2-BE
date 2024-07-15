using System;
using System.ComponentModel.DataAnnotations;

namespace Spedizioni.Models
{
    public class AggiornamentoSpedizione
    {
        public int Id { get; set; }

        [Required]
        public int SpedizioneId { get; set; }

        [Required]
        public string Stato { get; set; } // In transito, In consegna, Consegnato, Non consegnato

        [Required]
        public string Luogo { get; set; }

        public string Descrizione { get; set; }

        [Required]
        public DateTime DataOraAggiornamento { get; set; }

        public Spedizione Spedizione { get; set; }
    }
}

