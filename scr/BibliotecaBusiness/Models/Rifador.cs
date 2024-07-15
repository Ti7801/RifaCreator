using System.ComponentModel.DataAnnotations;

namespace BibliotecaBusiness.Models
{
    public class Rifador
    {
        [Required]
        public long Id { get; set; } 
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Senha { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Telefone { get; set; }

    }
}
