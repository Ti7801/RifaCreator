using BibliotecaBusiness.Models;
using BibliotecaBusiness.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RifaFacilWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/rifador")]
    public class RifadorController : ControllerBase
    {
        private readonly CadastrarRifadorService cadastrarRifadorService;  
        private readonly ConsultarRifadorService consultarRifadorService;
        private readonly AtualizarRifadorService atualizarRifadorService;
        private readonly ExcluirRifadorService excluirRifadorService;

        public RifadorController(CadastrarRifadorService cadastrarRifadorService,
                                 ConsultarRifadorService consultarRifadorService,
                                 AtualizarRifadorService atualizarRifadorService,
                                 ExcluirRifadorService excluirRifadorService) 
        { 
            this.cadastrarRifadorService = cadastrarRifadorService;
            this.consultarRifadorService = consultarRifadorService;
            this.atualizarRifadorService = atualizarRifadorService;
            this.excluirRifadorService = excluirRifadorService;
        }
        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
        [HttpPut]
        [ProducesResponseType(typeof(Rifador), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Rifador> AtualizarRifador(Rifador rifador)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(x => x.Errors).Select(erros => erros.ErrorMessage).SingleOrDefault();
                return BadRequest(erros);   
            }

            ServiceResult serviceResult = atualizarRifadorService.AtualizarRifador(rifador);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Erros);
            }

            return Ok(rifador);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        [ProducesResponseType(typeof(Rifador), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Rifador> ExcluirRifador(Rifador rifador)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(x => x.Errors).Select(erros => erros.ErrorMessage).SingleOrDefault();

                return BadRequest(erros);
            }

            ServiceResult serviceResult = excluirRifadorService.ExcluirRifador(rifador);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Erros);
            }

            return Ok(rifador);
        }
    }
}
