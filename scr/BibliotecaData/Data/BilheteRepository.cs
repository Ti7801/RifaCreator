using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;
using BibliotecaBusiness.Exceptions;

namespace BibliotecaData.Data
{
    public class BilheteRepository : IBilheteRepository
    {
        private readonly AppDbContext appDbContext;

        public BilheteRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void AdicionarBilhete(Bilhete bilhete)
        {
            appDbContext.Bilhetes.Add(bilhete);
            appDbContext.SaveChanges();
        }

        public void AtualizaBilhete(Bilhete bilhete)
        {
            Bilhete? bilhetePesquisado = ObterBilhetePorId(bilhete.Id);

            if (bilhetePesquisado == null)
            {               
                const string message = "Identificação do bilhete não encontrada";
                throw new BilheteNaoEncontradoException(message);
            }

            bilhetePesquisado.Nome = bilhete.Nome;
            bilhetePesquisado.Telefone = bilhete.Telefone;
            bilhetePesquisado.Email = bilhete.Email;

            appDbContext.Bilhetes.Update(bilhete);
            appDbContext.SaveChanges();
        }

        public Bilhete? ObterBilhetePorId(long id)
        {
            Bilhete? bilhete = appDbContext.Bilhetes.Where(x => x.Id == id).SingleOrDefault();

            return bilhete;
        }

        public Bilhete? SorteioBilhete(List<Bilhete> bilhetes)
        {
            Random rnd = new Random();
            var idBilhete = rnd.Next(0, bilhetes.Count);

            Bilhete? bilheteAleatorio = ObterBilhetePorId(idBilhete);

            if (bilheteAleatorio == null)
            {
                const string message = "Identificação do bilhete não encontrado.";
                throw new BilheteNaoEncontradoException(message);
            }

            return bilheteAleatorio;
        }

        public void ExcluirBilhete(Bilhete bilhete)
        {
            appDbContext.Bilhetes.Remove(bilhete);
            appDbContext.SaveChanges();
        }
    }
}
