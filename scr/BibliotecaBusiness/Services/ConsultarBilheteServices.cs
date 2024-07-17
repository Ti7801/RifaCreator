using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class ConsultarBilheteServices
    {
        private readonly IBilheteRepository bilheteRepository;

        public ConsultarBilheteServices(IBilheteRepository bilheteRepository)
        {
            this.bilheteRepository = bilheteRepository;
        }

        public Bilhete? ConsultarBilhete(long id)
        {
            Bilhete? bilhetePesquisado = bilheteRepository.ObterBilhetePorId(id);
              
            return bilhetePesquisado;
        }
    }
}
