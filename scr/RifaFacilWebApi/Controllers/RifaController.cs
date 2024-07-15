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
        private readonly CadastrarRifaServices cadastrarRifaServices;

        public RifaController(CadastrarRifaServices cadastrarRifaServices)
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
    }
}
