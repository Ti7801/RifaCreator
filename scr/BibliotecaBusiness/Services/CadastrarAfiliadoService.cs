using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class CadastrarAfiliadoService
    {
        private readonly IAfiliadoRepository afiliadoRepository;

        public CadastrarAfiliadoService(IAfiliadoRepository afiliadoRepository)
        {
            this.afiliadoRepository = afiliadoRepository;   
        }

        public ServiceResult CadastrarAfiliado(Afiliado afiliado)
        {
            ServiceResult serviceResult = new ServiceResult();  

            try{
                afiliadoRepository.AdicionarAfiliado(afiliado);
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
