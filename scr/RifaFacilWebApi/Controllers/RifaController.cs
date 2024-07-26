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
        private readonly ConsultarRifaService consultarRifaService;
        private readonly AtualizarRifaService atualizarRifaService;

        public RifaController(CadastrarRifaService cadastrarRifaServices,
                              ConsultarRifaService consultarRifaService,
                              AtualizarRifaService atualizarRifaService)
        {
            this.cadastrarRifaServices = cadastrarRifaServices;
            this.consultarRifaService = consultarRifaService;
            this.atualizarRifaService = atualizarRifaService;
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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Rifa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Rifa> ConsultarRifa(long id)
        {
            Rifa? rifa = consultarRifaService.ConsultarRifa(id);

            if (rifa == null)
            {
                return BadRequest();
            }

            return Ok(rifa);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Rifa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ServiceResult> AtualizarRifa(Rifa rifa)
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

            return Ok(serviceResult);
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
