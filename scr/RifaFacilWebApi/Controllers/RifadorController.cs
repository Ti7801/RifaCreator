using BibliotecaBusiness.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace RifaFacilWebApi.Controllers
{
    [ApiController]
    [Route("rifador")]
    public class RifadorController : ControllerBase
    {



        public RifadorController() { }  


        [HttpPost]
        [ProducesResponseType(typeof(Rifador), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Rifador> AdicionarRifador()
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(u => u.Errors).Select(error => error.ErrorMessage);
                return BadRequest(erros);
            }


            return CreatedAtAction();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Rifador), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Rifador> ObterRifador() 
        {

            return new Rifador();
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
