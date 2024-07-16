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

        public ServiceResult ConsultarBilhete(Bilhete bilhete)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                bilheteRepository.ObterBilhetePorId(bilhete.Id);
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
