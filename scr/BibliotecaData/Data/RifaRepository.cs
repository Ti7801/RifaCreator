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
                const string message = "Identificação da rifa não encontrada";
                throw new RifadorNaoEncontradoException(message);
            }

            rifaPesquisada.Premio = rifa.Premio;
            rifaPesquisada.DataSorteio = rifa.DataSorteio;
            rifaPesquisada.ValorBilhete = rifa.ValorBilhete;
            rifaPesquisada.Status = rifa.Status;

            appDbContext.Rifas.Update(rifaPesquisada);
            appDbContext.SaveChanges();
        }

        public Rifa? ObterRifa(long id)
        {
            Rifa? rifaretorno = appDbContext.Rifas.Where(rifa => rifa.Id == id).SingleOrDefault();

            return rifaretorno;
        }

        public void ExcluirRifa(Rifa rifa)
        {
            appDbContext.Rifas.Remove(rifa);    
            appDbContext.SaveChanges();
        }
    }
}
