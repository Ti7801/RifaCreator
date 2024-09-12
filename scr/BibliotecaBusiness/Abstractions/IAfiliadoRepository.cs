using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Abstractions
{
    public interface IAfiliadoRepository
    {
        public void AdicionarAfiliado(Afiliado afiliado);
        public List<Afiliado> ObterAfiliados();
        public Afiliado? ObterAfiliadoPorId(long id);
        public void AtualizarAfiliado(Afiliado afiliado);
        public void RemoverAfiliado(Afiliado afiliado);
    }
}
