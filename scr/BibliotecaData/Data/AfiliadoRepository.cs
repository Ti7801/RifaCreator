using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Exceptions;
using BibliotecaBusiness.Models;

namespace BibliotecaData.Data
{
    public class AfiliadoRepository : IAfiliadoRepository
    {
        private readonly AppDbContext appDbContext;

        public AfiliadoRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void AdicionarAfiliado(Afiliado afiliado)
        {
            appDbContext.Afiliados.Add(afiliado);
            appDbContext.SaveChanges(); 
        }

        public List<Afiliado> ObterAfiliados()
        {
           List<Afiliado>? afiliados = appDbContext.Afiliados.ToList();

            return afiliados;
        }

        public Afiliado? ObterAfiliadoPorId(long id)
        {
            Afiliado? afiliado = appDbContext.Afiliados.Where(x => x.Id == id).SingleOrDefault();

            return afiliado;
        }

        public void AtualizarAfiliado(Afiliado afiliado)
        {
            Afiliado? afiliadoParaAtualizacao = ObterAfiliadoPorId(afiliado.Id);

            if (afiliadoParaAtualizacao == null) 
            {
                const string messege = "Identificação do Afiliado não encontrada";
                throw new AfiliadoNaoEncontradoException(messege);
            }

            afiliadoParaAtualizacao.Nome = afiliado.Nome;
            afiliadoParaAtualizacao.Email = afiliado.Email; 
            afiliadoParaAtualizacao.Telefone = afiliado.Telefone;

            appDbContext.Afiliados.Update(afiliadoParaAtualizacao);
            appDbContext.SaveChanges(); 
        }

        public void RemoverAfiliado(Afiliado afiliado)
        {
            appDbContext.Afiliados.Remove(afiliado);
            appDbContext.SaveChanges();
        }
    }
}
