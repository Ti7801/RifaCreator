using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Exceptions;
using BibliotecaBusiness.Models;
using System.ComponentModel;

namespace BibliotecaData.Data
{
    public class RifaRepository : IRifaRepository
    {
        private readonly AppDbContext appDbContext;

        public RifaRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void AdicionarRifa(Rifa rifa)
        {
            appDbContext.Rifas.Add(rifa);
            appDbContext.SaveChanges(); 
        }

        public void AtualizarRifa(Rifa rifa)
        {
            Rifa? rifaPesquisada = ObterRifa(rifa.Id);

            if (rifaPesquisada == null)
            {
                const string message = "A identificação de rifa não foi encontrada.";
                throw new RifaNaoEncontradaException(message);
            }

            rifaPesquisada.Status = rifa.Status;

            appDbContext.Rifas.Update(rifaPesquisada);
            appDbContext.SaveChanges();
        }

        public Rifa? ObterRifa(long id)
        {
            var rifaretorno = appDbContext.Rifas.Where(rifa => rifa.Id == id).SingleOrDefault();

            return rifaretorno;
        }

        public void ExcluirRifa(Rifa rifa)
        {
            appDbContext.Rifas.Remove(rifa);    
            appDbContext.SaveChanges();
        }

    }
}
