using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class ExcluirRifaService
    {
        private readonly IRifaRepository rifaRepository;

        public ExcluirRifaService(IRifaRepository rifaRepository)
        {
            this.rifaRepository = rifaRepository;
        }

        public ServiceResult ExcluirRifa(Rifa rifa)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                rifaRepository.ExcluirRifa(rifa);
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
