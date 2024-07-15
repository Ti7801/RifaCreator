using System.ComponentModel.DataAnnotations;

namespace BibliotecaBusiness.Models
{
    public class Rifa
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string? Status { get; set; }

        [Required]
        public long RifadorId { get; set; }
    }
}
