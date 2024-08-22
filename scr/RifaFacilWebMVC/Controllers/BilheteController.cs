using BibliotecaBusiness.Models;
using BibliotecaBusiness.Services;
using Microsoft.AspNetCore.Mvc;

namespace RifaFacilWebMVC.Controllers
{
    [Route("bilhete")]
    public class BilheteController : Controller
    {
        private readonly ComprarBilheteService comprarBilheteService; 
        private readonly ConsultarBilheteService consultarBilheteService;

        public BilheteController(ConsultarBilheteService consultarBilheteService,
                                 ComprarBilheteService comprarBilheteService)
        {
            this.consultarBilheteService = consultarBilheteService;
            this.comprarBilheteService = comprarBilheteService;
        }

        [HttpPost]
        public IActionResult CriarBilhete(Bilhete bilhete)
        {

            return View();
        }

        [HttpGet]
        public IActionResult CriarBilhete()
        {
            return View();
        }




        [HttpGet("{id}:int")]
        public IActionResult ConsultarBilhete(long id)
        {
            Bilhete? bilhete = consultarBilheteService.ConsultarBilhete(id);

            if (bilhete == null)
            {
                return NotFound();
            }

            return View(bilhete);
        }

    }
}
