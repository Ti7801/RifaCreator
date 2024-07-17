using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class StatusDaRifaService
    {
        private readonly IRifaRepository rifaRepository;

        public StatusDaRifaService(IRifaRepository rifaRepository)
        {
            this.rifaRepository = rifaRepository;
        }

        public Rifa? StatusRifa(long id)
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
