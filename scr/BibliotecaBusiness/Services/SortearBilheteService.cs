using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Exceptions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class SortearBilheteService
    {
        private readonly IBilheteRepository bilheteRepository;

        public SortearBilheteService(IBilheteRepository bilheteRepository)
        {
            this.bilheteRepository = bilheteRepository;
        }

        public Bilhete? SorteioBilhete(List<Bilhete> bilhetes)
        {
            Random rnd = new Random();
            var idBilhete = rnd.Next(0, bilhetes.Count);

            Bilhete? bilheteAleatorio = bilheteRepository.ObterBilhetePorId(idBilhete);

            if (bilheteAleatorio == null)
            {
                return null;
            }

            return bilheteAleatorio;
        }
    }
}
