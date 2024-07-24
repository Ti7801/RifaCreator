using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Abstractions
{
    public interface IBilheteRepository
    {
        public void AdicionarBilhete(Bilhete bilhete);
        public Bilhete? ObterBilhetePorId(long id);
        public void AtualizaBilhete(Bilhete bilhete);
        public void ExcluirBilhete(Bilhete bilhete);
        public List<Bilhete> ListaDeBilhetes();
    }
}
