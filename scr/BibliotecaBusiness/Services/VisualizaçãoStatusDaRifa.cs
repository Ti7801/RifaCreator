using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class VisualizaçãoStatusDaRifa
    {
        private readonly IRifaRepository rifaRepository;

        public VisualizaçãoStatusDaRifa(IRifaRepository rifaRepository)
        {
            this.rifaRepository = rifaRepository;
        }

        public ServiceResult VisualizarStatusRifa(long id)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                rifaRepository.StatusRifa(id);
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
