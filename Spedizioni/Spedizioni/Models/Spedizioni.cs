using System;
using System.ComponentModel.DataAnnotations;

namespace Spedizioni.Models
{
    public class Spedizione
    {
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public string NumeroIdentificativo { get; set; }

        [Required]
        public DateTime DataSpedizione { get; set; }

        [Required]
        public decimal Peso { get; set; }

        [Required]
        public string CittaDestinatario { get; set; }

        [Required]
        public string IndirizzoDestinatario { get; set; }

        [Required]
        public string NomeDestinatario { get; set; }

        [Required]
        public decimal Costo { get; set; }

        [Required]
        public DateTime DataConsegnaPrevista { get; set; }

        public Cliente Cliente { get; set; }
    }
}

