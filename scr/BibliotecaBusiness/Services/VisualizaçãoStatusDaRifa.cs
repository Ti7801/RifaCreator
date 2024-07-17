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

        public string? StatusRifa(long id)
        {        
            string? status =  rifaRepository.ObterStatusRifa(id);

            return status;
        }
    }
}
