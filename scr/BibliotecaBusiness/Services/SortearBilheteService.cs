using BibliotecaBusiness.Abstractions;
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

        public Bilhete? SortearBilhete(List<Bilhete> bilhetes)
        {
            return bilheteRepository.SorteioBilhete(bilhetes);                             
        }
    }
}
