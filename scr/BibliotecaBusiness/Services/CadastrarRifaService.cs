using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class CadastrarRifaService
    {
        private readonly IRifaRepository rifaRepository;

        public CadastrarRifaService(IRifaRepository rifaRepository)
        {
            this.rifaRepository = rifaRepository;
        }

        public ServiceResult CadastrarRifa(Rifa rifa)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                rifaRepository.AdicionarRifa(rifa);
                serviceResult.Success = true;
            }
            catch(Exception e)
            {
                serviceResult.Success = false;  
                serviceResult.Erros.Add(e.Message);                 
            }
            return serviceResult;
        }
    }
}
