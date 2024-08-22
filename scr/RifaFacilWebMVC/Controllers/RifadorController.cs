using Microsoft.AspNetCore.Mvc;
using BibliotecaBusiness.Models;
using BibliotecaBusiness.Services;

namespace RifaFacilWebMVC.Controllers
{
    [Route("rifador")]
    public class RifadorController : Controller
    {
        private readonly ConsultarRifadorService consultarRifadorService;

        public RifadorController(ConsultarRifadorService consultarRifadorService) 
        {
        this.consultarRifadorService = consultarRifadorService;
        }

        [HttpGet("{id:int}")]
        public IActionResult ConsultarRifador(long id) 
        {
            Rifador? rifador = consultarRifadorService.ConsultarRifador(id);

            if (rifador == null)
            {
                return View("NotFound");  
            }

            return View(rifador);  
        }
    }
}
