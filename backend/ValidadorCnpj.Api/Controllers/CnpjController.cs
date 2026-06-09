using Microsoft.AspNetCore.Mvc;
using ValidadorCnpj.Application.Models;
using ValidadorCnpj.Application.Services.Interfaces;

namespace ValidadorCnpj.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CnpjController : ControllerBase
    {
        private readonly ICnpjServices _cnpjService;
        public CnpjController(ICnpjServices cnpjService)
        {
            _cnpjService = cnpjService;
        }

        [HttpGet("validar/{cnpj}")]
        public ActionResult<CnpjResult> Validar(string cnpj)
        {
            CnpjResult result = _cnpjService.Valida(cnpj);
            
            if (!result.IsValido)
                return BadRequest(result);
            
            return Ok(result);
        }
    }
}
