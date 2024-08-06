using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class ComprarBilheteService
    {
        private readonly IBilheteRepository bilheteRepository;

        public ComprarBilheteService(IBilheteRepository bilheteRepository)
        {
            this.bilheteRepository = bilheteRepository;   
        }

        public ServiceResult ComprarBilhete(Bilhete bilhete)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                bilheteRepository.AdicionarBilhete(bilhete);
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
