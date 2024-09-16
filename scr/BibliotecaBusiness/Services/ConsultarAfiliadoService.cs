using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class ConsultarAfiliadoService
    {
        private readonly IAfiliadoRepository afiliadoRepository;

        public ConsultarAfiliadoService(IAfiliadoRepository afiliadoRepository)
        {
            this.afiliadoRepository = afiliadoRepository;   
        }

        public ServiceResult ConsultarAfiliado(Afiliado afiliado)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                serviceResult.Success = true;
                afiliadoRepository.AtualizarAfiliado(afiliado);
            }
            catch (Exception e) 
            {
                serviceResult.Success= false;   
                serviceResult.Erros.Add(e.Message); 
            }

            return serviceResult;
        }
    }
}
