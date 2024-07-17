using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class SortearBilheteServices
    {
        private readonly IBilheteRepository bilheteRepository;

        public SortearBilheteServices(IBilheteRepository bilheteRepository)
        {
            this.bilheteRepository = bilheteRepository;
        }

        public Bilhete? SortearBilhete(List<Bilhete> bilhetes)
        {
            Bilhete? bilhete = bilheteRepository.SorteioBilhete(bilhetes);
                
            return bilhete; 
        }
    }
}
