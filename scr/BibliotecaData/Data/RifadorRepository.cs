using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Exceptions;
using BibliotecaBusiness.Models;
using System.Linq;

namespace BibliotecaData.Data
{
    public class RifadorRepository : IRifadorRepository
    {
        private readonly AppDbContext appDbContext;

        public RifadorRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void AdicionarRifador(Rifador rifador)
        {
            appDbContext.Rifadores.Add(rifador);
            appDbContext.SaveChanges();
        }

        public void AtualizarRifador(Rifador rifador)
        {
            Rifador? rifadorPesquisado = ObterRifador(rifador.Id);

            if (rifadorPesquisado == null)
            {
                const string message = "A identificação do rifador não foi encontrada";
                throw new RifadorNaoEncontradoException(message);
            }

            rifadorPesquisado.Nome = rifador.Nome;
            rifadorPesquisado.Email = rifador.Email;
            rifadorPesquisado.Senha = rifador.Senha;
            rifadorPesquisado.Telefone = rifador.Telefone;

            appDbContext.Rifadores.Update(rifadorPesquisado);
            appDbContext.SaveChanges();
        }

        public Rifador? ObterRifador(long id)
        {
            Rifador? rifadorRetorno = appDbContext.Rifadores.Where(rifador => rifador.Id == id).SingleOrDefault();

            return rifadorRetorno;
        }

        public void ExcluirRifador(Rifador rifador)
        {
            appDbContext.Rifadores.Remove(rifador);   
            appDbContext.SaveChanges();
        }


        

        




        /*

        public void AtualizarBilhete(Bilhete bilhete)
        {
            appDbContext.Bilhetes.Update(bilhete);
            appDbContext.SaveChanges();
        }

        public void CadastrarRifa(Rifa rifa)
        {
            appDbContext.Rifas.Add(rifa);
            appDbContext.SaveChanges();
        }

        public void ExcluirConta(Rifador rifador)
        {
            appDbContext.Rifadores.Remove(rifador);
            appDbContext.SaveChanges();
        }
        public void ExcluirBilhete(Bilhete bilhete)
        {
            appDbContext.Bilhetes.Remove(bilhete);
            appDbContext.SaveChanges();
        }

        public Bilhete? SortearBilhete(List<Bilhete> bilhetes)
        {
            Random rnd = new Random();
            var idBilhete = rnd.Next(0, bilhetes.Count);

            var bilheteAleatorio = appDbContext.Bilhetes.Where(x => x.Id == idBilhete).SingleOrDefault();

            return bilheteAleatorio;
        }

        public string? VisualizarStatusRifa(int id)
        {
            Rifa? rifa = appDbContext.Rifas.Where(x => x.Id == id).SingleOrDefault();

            if (rifa == null)
            {

            }

            string? statusRifa = rifa.Status;

            return statusRifa;
        }

        public Bilhete? ConsultarBilhete(int id)
        {
            Bilhete? consultarBilhete = appDbContext.Bilhetes.Where(u => u.Id == id).SingleOrDefault();

            return consultarBilhete;
        }
        */

    }
}
