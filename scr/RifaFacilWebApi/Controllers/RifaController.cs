using BibliotecaBusiness.Services;
using BibliotecaData.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using BibliotecaBusiness.Models;
using Microsoft.AspNetCore.Authorization;

namespace RifaFacilWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("rifa")]
    public class RifaController : ControllerBase
    {
        private readonly CadastrarRifaService cadastrarRifaServices;
        private readonly ConsultarRifaService consultarRifaService;
        private readonly AtualizarRifaService atualizarRifaService;
        private readonly ExcluirRifaService excluirRifaService;

        public RifaController(CadastrarRifaService cadastrarRifaServices,
                              ConsultarRifaService consultarRifaService,
                              AtualizarRifaService atualizarRifaService,
                              ExcluirRifaService excluirRifaService)
        {
            this.cadastrarRifaServices = cadastrarRifaServices;
            this.consultarRifaService = consultarRifaService;
            this.atualizarRifaService = atualizarRifaService;
            this.excluirRifaService = excluirRifaService;   
        }

        [Authorize(Roles ="rifador")]
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

        [Authorize(Roles = "rifador")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Rifa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Rifa> ConsultarRifa(long id)
        {
            Rifa? rifa = consultarRifaService.ConsultarRifa(id);

            if (rifa == null)
            {
                return NotFound();
            }

            return Ok(rifa);
        }

        [Authorize(Roles = "rifador")]
        [HttpPut]
        [ProducesResponseType(typeof(Rifa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Rifa> AtualizarRifa(Rifa rifa)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(u => u.Errors).Select(error => error.ErrorMessage);
                return BadRequest(erros);
            }

            ServiceResult serviceResult = atualizarRifaService.AtualizarRifa(rifa);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Erros);
            }

            return Ok(rifa);
        }

        [Authorize(Roles = "rifador")]
        [HttpDelete]
        [ProducesResponseType(typeof(Rifa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Rifa> ExcluirRifa(Rifa rifa)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(x => x.Errors).Select(erros => erros.ErrorMessage).SingleOrDefault();

                return BadRequest(erros);
            }

            ServiceResult serviceResult = excluirRifaService.ExcluirRifa(rifa);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Erros);
            }

            return Ok(rifa);
        }
    }
}
