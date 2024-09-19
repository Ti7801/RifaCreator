using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class ConsultarAfiliadoPorIdService 
    {
        private readonly IAfiliadoRepository afiliadoRepository;

        public ConsultarAfiliadoPorIdService(IAfiliadoRepository afiliadoRepository)
        {
            this.afiliadoRepository = afiliadoRepository;   
        }

        public Afiliado? ConsultarAfiliadoPorId(long id)
        {
            try
            {
                Afiliado? afiliado = afiliadoRepository.ObterAfiliadoPorId(id); 
                return afiliado;
            }
            catch
            {
                return null;
            }
        }
    }
}
