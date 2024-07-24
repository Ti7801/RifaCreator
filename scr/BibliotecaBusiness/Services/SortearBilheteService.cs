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

        public Bilhete? SorteioBilhete()
        {
            List<Bilhete> bilheteAleatorio = bilheteRepository.ListaDeBilhetes() ;

            Random rnd = new Random();
            var idBilhete = rnd.Next(0, bilheteAleatorio.Count);

            Bilhete? bilheteEscolhido = bilheteAleatorio.Where(x => x.Id == idBilhete).SingleOrDefault();
         
            if (bilheteEscolhido == null)
            {
                return null;
            }

            return bilheteEscolhido;
        }
    }
}
