using BibliotecaBusiness.Models;
using BibliotecaBusiness.Services;
using Microsoft.AspNetCore.Mvc;

namespace RifaFacilWebApi.Controllers
{
    [ApiController]
    [Route("afiliado")]
    public class AfiliadoController : ControllerBase
    {
        private readonly CadastrarAfiliadoService cadastrarAfiliadoService;
        //private readonly ConsultarAfiliadoService consultarAfiliadoService;
        //private readonly AtualizarAfiliadoService atualizarAfiliadoService; 
        //private readonly ExcluirAfiliadoService excluirAfiliadoService; 

        public AfiliadoController(CadastrarAfiliadoService cadastrarAfiliadoService//,
                                 //ConsultarAfiliadoService consultarAfiliadoService,
                                 //AtualizarAfiliadoService atualizarAfiliadoService,
                                 //ExcluirAfiliadoService excluirAfiliadoService
                                 )
        {
            this.cadastrarAfiliadoService = cadastrarAfiliadoService;
            //this.consultarAfiliadoService = consultarAfiliadoService;
            //this.atualizarAfiliadoService = atualizarAfiliadoService;
            //this.excluirAfiliadoService = excluirAfiliadoService;
        }


        [HttpPost]
        [ProducesResponseType(typeof(Afiliado), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Afiliado> CadastrarAfiliado(Afiliado afiliado)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(X => X.Errors).Select(erros => erros.ErrorMessage).SingleOrDefault();

                return BadRequest(erros);   
            }

            ServiceResult serviceResult = cadastrarAfiliadoService.CadastrarAfiliado(afiliado);

            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Erros);
            }


            return CreatedAtAction(nameof(CadastrarAfiliado), afiliado);
        }
      
    }
}
