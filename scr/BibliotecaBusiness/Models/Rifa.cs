using System.ComponentModel.DataAnnotations;

namespace BibliotecaBusiness.Models
{
    public class Rifa
    {
        [Required]
        public long Id { get; set; }

        [Required] 
        public string? Premio { get; set; }

        [Required]
        public DateTime DataSorteio { get; set; }

        [Required]
        public float ValorBilhete { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public long RifadorId { get; set; }
    }
}
