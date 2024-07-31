using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class AtualizarRifadorService
    {
        private readonly IRifadorRepository rifadorRepository;

        public AtualizarRifadorService(IRifadorRepository rifadorRepository)
        {
            this.rifadorRepository = rifadorRepository;
        }

        public ServiceResult AtualizarRifador(Rifador rifador)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                rifadorRepository.AtualizarRifador(rifador);
                serviceResult.Success = true;
            }
            catch (Exception ex) 
            {
                serviceResult.Success = false;
                serviceResult.Erros.Add(ex.Message);    
            }

            return serviceResult;
        }

    }
}
