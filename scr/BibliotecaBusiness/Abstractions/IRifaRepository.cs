using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Abstractions
{
    public interface IRifaRepository
    {
        public void AdicionarRifa(Rifa rifa);
        public Rifa? ObterRifa(long id);
        public void AtualizarRifa(Rifa rifa);
        public void ExcluirRifa(Rifa rifa);
        public string? StatusRifa(long id);
    }
}
