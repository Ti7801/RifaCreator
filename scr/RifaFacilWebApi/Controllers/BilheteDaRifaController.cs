using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaBusiness.Models;
using BibliotecaData.Data;
using BibliotecaBusiness.Services;

namespace RifaFacilWebApi.Controllers
{
    public class BilheteController
    {
        [ApiController]
        [Route("controller")]
        public class BilheteDaRifaController : ControllerBase
        {
            private readonly AppDbContext appDbContext;
            
            public BilheteDaRifaController(AppDbContext appDbContext)
            {
                this.appDbContext = appDbContext;
            }

            [HttpPost]
            [ProducesResponseType(typeof(Bilhete), StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public ActionResult<Bilhete> CriarBilhete(Bilhete bilhete)
            {

                if (!ModelState.IsValid)
                {
                    var erros = ModelState.Values.SelectMany(u => u.Errors).Select(erros => erros.ErrorMessage);
                    return BadRequest(erros);
                }


                return CreatedAtAction(actionName: nameof(CriarBilhete), bilhete);
            }


            [HttpGet]
            [ProducesResponseType(typeof(Bilhete), StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult<List<Bilhete>> ListarBilhetes()
            {
                var lista = appDbContext.Bilhetes;

                if (lista == null)
                {
                    return NotFound();
                }

                return Ok(lista);
            }

            [HttpGet("sortear")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult<Bilhete> Sortear()
            {
                Random aleatorio = new Random();

                var inicio = appDbContext.Bilhetes.OrderBy(x => x.Id).FirstOrDefault();
                var fim = appDbContext.Bilhetes.OrderBy(x => x.Id).LastOrDefault();
                var valorEscolhido = aleatorio.NextInt64(inicio.Id, fim.Id);

                var escolhido = appDbContext.Bilhetes.Where(u => u.Id == valorEscolhido).SingleOrDefault();

                if (escolhido == null)
                {
                    return NotFound();
                }

                return Ok(escolhido);
            }

            [HttpPut]
            [ProducesResponseType(typeof(Bilhete), StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult<Bilhete> AtualizarBilhete(Bilhete bilhete)
            {
                

                return Ok(bilhetePesquisado);
            }


            [HttpDelete]
            [ProducesResponseType(typeof(Bilhete), StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult<Bilhete> DeletarBilhete(Bilhete bilhete)
            {
                var removerBilhete = appDbContext.Bilhetes.Where(u => u.Id == bilhete.Id).SingleOrDefault();

                if (removerBilhete == null)
                {
                    return NotFound();
                }

                appDbContext.Bilhetes.Remove(removerBilhete);
                appDbContext.SaveChanges();

                return Ok(removerBilhete);
            }
        }
    }
}
