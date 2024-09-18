using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class ExcluirAfiliadoService
    {
        private readonly IAfiliadoRepository afiliadoRepository;

        public ExcluirAfiliadoService(IAfiliadoRepository afiliadoRepository)
        {
            this.afiliadoRepository = afiliadoRepository;
        }

        public ServiceResult ExcluirAfiliado(Afiliado afiliado)
        {
            ServiceResult serviceResult = new ServiceResult();

            try 
            {
                afiliadoRepository.RemoverAfiliado(afiliado);
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
