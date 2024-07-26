using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class AtualizarRifaService
    {
        private readonly IRifaRepository rifaRepository;

        public AtualizarRifaService(IRifaRepository rifaRepository) 
        {
            this.rifaRepository = rifaRepository;   
        }

        public ServiceResult AtualizarRifa(Rifa rifa)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                rifaRepository.AtualizarRifa(rifa);
                serviceResult.Success = true;
            }
            catch (Exception e) 
            {
                serviceResult.Success = false;
                serviceResult.Erros.Add(e.Message);
            }

            return serviceResult;
        }
    }
}
