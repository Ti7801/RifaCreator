using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;


namespace BibliotecaBusiness.Services
{
    public class ConsultarRifadorService
    {
        private readonly IRifadorRepository rifadorRepository;

        public ConsultarRifadorService(IRifadorRepository rifadorRepository)
        {
            this.rifadorRepository = rifadorRepository; 
        }

        public Rifador? ConsultarRifador(long id)
        {
            try 
            {
                return rifadorRepository.ObterRifador(id);
            }
            catch
            {
                return null;
            }                    
        }
    }
}
