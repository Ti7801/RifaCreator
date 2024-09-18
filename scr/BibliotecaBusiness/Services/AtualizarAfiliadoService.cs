using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class AtualizarAfiliadoService
    {
        private readonly IAfiliadoRepository afiliadoRepository;

        public AtualizarAfiliadoService(IAfiliadoRepository afiliadoRepository)
        {
            this.afiliadoRepository = afiliadoRepository;
        }

        public ServiceResult AtualizarAfiliado(Afiliado afiliado)
        {
            ServiceResult serviceResult = new ServiceResult();

            try 
            {
                afiliadoRepository.AtualizarAfiliado(afiliado);
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
