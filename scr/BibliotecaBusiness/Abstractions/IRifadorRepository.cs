using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Abstractions
{
    public interface IRifadorRepository
    {
        public void AdicionarRifador(Rifador rifador); 
        public Rifador? ObterRifador(long id);
        public void AtualizarRifador(Rifador rifador);
        public void ExcluirRifador(Rifador rifador);
    }
}
