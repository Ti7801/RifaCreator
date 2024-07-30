using BibliotecaBusiness.Models;
using BibliotecaBusiness.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace RifaFacilWebApi.Controllers
{
    [ApiController]
    [Route("rifador")]
    public class RifadorController : ControllerBase
    {
        private readonly CadastrarRifadorService cadastrarRifadorService;  
        private readonly ConsultarRifadorService consultarRifadorService;

        public RifadorController(CadastrarRifadorService cadastrarRifadorService,
                                 ConsultarRifadorService consultarRifadorService) 
        { 
            this.cadastrarRifadorService = cadastrarRifadorService;
            this.consultarRifadorService = consultarRifadorService;
        }  

        [HttpPost]
        [ProducesResponseType(typeof(Rifador), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Rifador> AdicionarRifador(Rifador rifador)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(u => u.Errors).Select(error => error.ErrorMessage);
                return BadRequest(erros);
            }

            ServiceResult serviceResult = cadastrarRifadorService.CadastrarRifador(rifador);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Erros);
            }

            return CreatedAtAction(nameof(AdicionarRifador), rifador);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Rifador), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Rifador> ObterRifador(long id) 
        {
            Rifador? rifador = consultarRifadorService.ConsultarRifador(id);

            if (rifador == null)
            {
                return BadRequest();
            }

            return Ok(rifador);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Rifador), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Rifador> AtualizarRifador()
        {


            return new Rifador();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Rifador), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Rifador> ExcluirRifador()
        {


            return new Rifador();
        }

    }
}
