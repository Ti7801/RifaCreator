using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class ConsultarBilheteService
    {
        private readonly IBilheteRepository bilheteRepository;

        public ConsultarBilheteService(IBilheteRepository bilheteRepository)
        {
            this.bilheteRepository = bilheteRepository;
        }

        public Bilhete? ConsultarBilhete(long id)
        {
            try
            {
                return bilheteRepository.ObterBilhetePorId(id);
            }
            catch
            {
                return null;
            }                                      
        }
    }
}
