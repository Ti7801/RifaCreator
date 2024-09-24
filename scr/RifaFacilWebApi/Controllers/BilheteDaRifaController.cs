using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaBusiness.Models;
using BibliotecaData.Data;
using BibliotecaBusiness.Services;
using BibliotecaBusiness.Abstractions;

namespace RifaFacilWebApi.Controllers
{
    [ApiController]
    [Route("bilhete")]
    public class BilheteDaRifaController : ControllerBase
    {
        private readonly ComprarBilheteService comprarBilheteService;
        private readonly VenderBilheteService venderBilheteService; 
        private readonly ConsultarBilheteService consultarBilheteService;
        private readonly SortearBilheteService sortearBilheteService;
        private readonly AtualizarBilheteService atualizarBilheteService;   
        private readonly ExcluirBilheteService excluirBilheteService;

        public BilheteDaRifaController(ComprarBilheteService comprarBilheteService,
                                       VenderBilheteService venderBilheteService,
                                       ConsultarBilheteService consultarBilhete, 
                                       SortearBilheteService sortearBilheteService, 
                                       AtualizarBilheteService atualizarBilheteService,
                                       ExcluirBilheteService excluirBilheteService) 
        {
            this.comprarBilheteService = comprarBilheteService;
            this.venderBilheteService = venderBilheteService;
            this.consultarBilheteService = consultarBilhete;
            this.sortearBilheteService = sortearBilheteService;
            this.atualizarBilheteService = atualizarBilheteService;
            this.excluirBilheteService = excluirBilheteService;            
        }
       
        [HttpPost("criarbilhete")]
        [ProducesResponseType(typeof(Bilhete), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Bilhete> CriarBilhete(Bilhete bilhete)
        {

            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(u => u.Errors).Select(erros => erros.ErrorMessage);
                return BadRequest(erros);
            }

            ServiceResult serviceResult = comprarBilheteService.ComprarBilhete(bilhete);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Erros);
            }

            return CreatedAtAction(actionName: nameof(CriarBilhete), bilhete);
        }

        [HttpPost("venderbilhete")]
        [ProducesResponseType(typeof(Bilhete), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Bilhete> VenderBilhete(Bilhete bilhete)
        {

            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(u => u.Errors).Select(erros => erros.ErrorMessage);
                return BadRequest(erros);
            }

            ServiceResult serviceResult = venderBilheteService.VenderBilhete(bilhete);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Erros);
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Bilhete> SortearBilhete()
        {
            Bilhete? BilheteSorteado = sortearBilheteService.SorteioBilhete();

            if (BilheteSorteado == null)
            {
                return Problem(detail:"Ocorreu um erro no sorteio da rifa, tente novamente", statusCode:StatusCodes.Status500InternalServerError,title:"Error no sorteio da rifa!");
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
                return BadRequest(serviceResult.Erros);
            }

            return Ok(bilhete);
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

            ServiceResult serviceResult = excluirBilheteService.ExcluirBilhete(bilhete);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Erros);
            }

            return Ok(bilhete);
        }
    }
    
}
