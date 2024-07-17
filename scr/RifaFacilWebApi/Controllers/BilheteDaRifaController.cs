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

        public BilheteDaRifaController(ConsultarBilheteService consultarBilhete) 
        { 
            this.consultarBilheteService = consultarBilhete;
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
        public ActionResult<Bilhete> ObterBilhete(long id)
        {
            Bilhete bilhete = consultarBilheteService.ConsultarBilhete(id);


            return bilhete;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Bilhete> Sortear()
        {





            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(Bilhete), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Bilhete> AtualizarBilhete(Bilhete bilhete)
        {
                

            return Ok();
        }


        [HttpDelete]
        [ProducesResponseType(typeof(Bilhete), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Bilhete> DeletarBilhete(Bilhete bilhete)
        {
           
            

            return Ok();
        }
    }
    
}
