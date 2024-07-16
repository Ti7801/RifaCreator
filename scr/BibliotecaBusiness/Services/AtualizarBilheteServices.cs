﻿using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class AtualizarBilheteServices
    {
        private readonly IBilheteRepository bilheteRepository;

        public AtualizarBilheteServices(IBilheteRepository bilheteRepository)
        {
            this.bilheteRepository = bilheteRepository;
        }

        public ServiceResult AtualizarBilhete(Bilhete bilhete)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                bilheteRepository.AtualizaBilhete(bilhete);
                serviceResult.Success = true;
            }
            catch (Exception e) 
            {                              
                serviceResult.Erros.Add(e.Message);
            }

            return serviceResult;
        }
    }
}