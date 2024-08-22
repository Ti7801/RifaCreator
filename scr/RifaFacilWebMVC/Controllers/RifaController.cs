using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;
using BibliotecaBusiness.Services;
using Microsoft.AspNetCore.Mvc;

namespace RifaFacilWebMVC.Controllers
{
    [Route("rifa")]
    public class RifaController: Controller
    {
        private readonly ConsultarRifaService consultarRifaService;

        public RifaController(ConsultarRifaService consultarRifaService) 
        {
            this.consultarRifaService = consultarRifaService;
        }

        [HttpGet("{id:int}")]
        public IActionResult ConsultarRifa(long id) 
        {
            Rifa? rifa = consultarRifaService.ConsultarRifa(id);

            if (rifa == null)
            {
                return View("NotFound");
            }

            return View(rifa);
        }
    }
}
