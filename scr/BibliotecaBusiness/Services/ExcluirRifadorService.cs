using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class ExcluirRifadorService
    {
        private readonly  IRifadorRepository rifadorRepository;

        public ExcluirRifadorService(IRifadorRepository rifadorRepository)
        {
            this.rifadorRepository = rifadorRepository; 
        }

        public ServiceResult ExcluirRifador(Rifador rifador)
        {
            ServiceResult serviceResult = new ServiceResult(); 
            
            try
            {
                rifadorRepository.ExcluirRifador(rifador);
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
