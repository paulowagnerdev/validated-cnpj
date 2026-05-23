using Microsoft.AspNetCore.Mvc;

namespace CnpjApi.Controllers
{
    [ApiController]
    [Route("/cnpj")]

    public class CnpjController : ControllerBase
    {
        [HttpPost("validate")]
        public IActionResult Teste([FromBody] string cnpj)
        {
            return Ok(cnpj);
        }
    }
}
