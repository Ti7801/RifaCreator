using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaBusiness.Models;
using BibliotecaData.Data;
using BibliotecaBusiness.Services;
using BibliotecaBusiness.Abstractions;

namespace RifaFacilWebApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class BilheteDaRifaController : ControllerBase
    {
        private readonly ConsultarBilheteService consultarBilheteService;
        private readonly SortearBilheteService sortearBilheteService;
        private readonly AtualizarBilheteService atualizarBilheteService;   
        private readonly ExcluirBilheteService excluirBilheteService;

        public BilheteDaRifaController(ConsultarBilheteService consultarBilhete, 
                                       SortearBilheteService sortearBilheteService, 
                                       AtualizarBilheteService atualizarBilheteService,
                                       ExcluirBilheteService excluirBilheteService) 
        { 
            this.consultarBilheteService = consultarBilhete;
            this.sortearBilheteService = sortearBilheteService;
            this.atualizarBilheteService = atualizarBilheteService;
            this.excluirBilheteService = excluirBilheteService;
        }
        // COMPRAR BILHETE
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


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Bilhete), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Bilhete> ObterBilhete(long id)
        {
            Bilhete? bilhete = consultarBilheteService.ConsultarBilhete(id);

            if (bilhete == null)
            {
                NotFound();
            }

            return Ok(bilhete);
        }

        [HttpGet("sortear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Bilhete> SortearBilhete()
        {
            Bilhete? BilheteSorteado = sortearBilheteService.SorteioBilhete();

            if (BilheteSorteado == null)
            {
                BadRequest();
            }

            return Ok(BilheteSorteado);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Bilhete), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Bilhete> AtualizarBilhete(Bilhete bilhete)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(x => x.Errors).Select(erros => erros.ErrorMessage).SingleOrDefault();
                return BadRequest(erros);
            }

            ServiceResult serviceResult = atualizarBilheteService.AtualizarBilhete(bilhete);

            if (!serviceResult.Success)
            {
                BadRequest(serviceResult.Erros);
            }

            return Ok(serviceResult);
        }


        [HttpDelete]
        [ProducesResponseType(typeof(Bilhete), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Bilhete> DeletarBilhete(Bilhete bilhete)
        {
            if (!ModelState.IsValid) // Verifica se os dados recebidos pela solicitação HTTP são validos
            {
                var erros = ModelState.Values.SelectMany(x => x.Errors).Select(erros => erros.ErrorMessage).SingleOrDefault();
                return BadRequest(erros);
            }

            ServiceResult bilheteExcluido = excluirBilheteService.ExcluirBilhete(bilhete);

            if (!bilheteExcluido.Success)
            {
                return BadRequest(bilheteExcluido.Erros);
            }

            return Ok(bilheteExcluido);
        }
    }
    
}
