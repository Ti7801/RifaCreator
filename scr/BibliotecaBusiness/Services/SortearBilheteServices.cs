using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class SortearBilheteServices
    {
        private readonly IBilheteRepository bilheteRepository;

        public SortearBilheteServices(IBilheteRepository bilheteRepository)
        {
            this.bilheteRepository = bilheteRepository;
        }

        public void SortearBilhete(List<Bilhete> bilhetes)
        {
            ServiceResult serviceResult = new ServiceResult();

            try 
            {
                bilheteRepository.SorteioBilhete(bilhetes);
                serviceResult.Success = true;
            }
            catch (Exception e) 
            {
                serviceResult.Success = false;
                serviceResult.Erros.Add(e.Message);
            }
        }

    }
}
