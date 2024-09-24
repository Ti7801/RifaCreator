using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class VenderBilheteService 
    {
        private readonly IBilheteRepository bilheteRepository;

        public VenderBilheteService(IBilheteRepository bilheteRepository)
        {
            this.bilheteRepository = bilheteRepository;
        }

        public ServiceResult VenderBilhete(Bilhete bilhete)
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
