using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class ConsultarRifaService
    {
        private readonly IRifaRepository rifaRepository;

        public ConsultarRifaService(IRifaRepository rifaRepository)
        {
            this.rifaRepository = rifaRepository;
        }

        public Rifa? ConsultarRifa(long id)
        {  
            try 
            {
                return rifaRepository.ObterRifa(id);
            }
            catch
            {
                return null;
            }
        }
    }
}
