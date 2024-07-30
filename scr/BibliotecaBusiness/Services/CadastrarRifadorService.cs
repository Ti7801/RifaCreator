using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class CadastrarRifadorService
    {
        private readonly IRifadorRepository rifadorRepository;

        public CadastrarRifadorService(IRifadorRepository rifadorRepository)
        {
            this.rifadorRepository = rifadorRepository;
        }

        public ServiceResult CadastrarRifador(Rifador rifador)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                rifadorRepository.AdicionarRifador(rifador);
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
