using BibliotecaBusiness.Services;
using BibliotecaData.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using BibliotecaBusiness.Models;

namespace RifaFacilWebApi.Controllers
{
    [ApiController]
    [Route("rifa")]
    public class RifaController : ControllerBase
    {
        private readonly CadastrarRifaService cadastrarRifaServices;

        public RifaController(CadastrarRifaService cadastrarRifaServices)
        {
            this.cadastrarRifaServices = cadastrarRifaServices;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Rifa), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Rifa> CadastrarRifa(Rifa rifa)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(u => u.Errors).Select(error => error.ErrorMessage);
                return BadRequest(erros);
            }
            
            var serviceResult = cadastrarRifaServices.CadastrarRifa(rifa);

            if (!serviceResult.Success) 
            {
                return BadRequest(serviceResult.Erros);
            }

            return CreatedAtAction(nameof(CadastrarRifa), rifa);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Rifa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Rifa> ObterRifa()
        {


            return new Rifa();
        }

        [HttpPut]
        [ProducesResponseType(typeof(Rifa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Rifa> AtualizarRifa()
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(u => u.Errors).Select(error => error.ErrorMessage);
                return BadRequest(erros);
            }


            return new Rifa();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Rifa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Rifa> ExcluirRifa()
        {


            return new Rifa();
        }


    }
}
