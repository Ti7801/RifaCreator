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

        public List<Afiliado> ConsultarAfiliado()
        {
            try
            {
               List<Afiliado> afiliados =  afiliadoRepository.ObterAfiliados();

                return afiliados;
            }
            catch 
            {
                return null;
         
            }
        }
    }
}
