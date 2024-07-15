using System.ComponentModel.DataAnnotations;

namespace BibliotecaBusiness.Models
{
    public class Bilhete
    {
        [Required]
        public long Id { get; set; }
        [Required(ErrorMessage = "É necessário o nome do comprador da rifa!")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "É necessário o telefone do comprador da rifa!")]
        public string? Telefone { get; set; }
        [Required(ErrorMessage = "É necessário o Email do comprador da rifa!")]
        public string? Email { get; set; }
        [Required]
        public long  RifaId { get; set; }

    }
}
