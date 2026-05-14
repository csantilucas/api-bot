using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api_bot.Services; 
using api_bot.models;   

namespace api_bot.Controllers
{
    [ApiController]
    [Route("data/cliente")]
    public class clientController : ControllerBase
    {
      
        private readonly ClientServiceImp _clientService;

        
        public clientController(ClientServiceImp clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("buscar")]
        public async Task<IActionResult> BuscarPorCpf([FromBody] BuscaRequest request)
        {
            var resultado = await _clientService.BuscarPorCpfAsync(request.Documento);
            return Ok(resultado);
        }
    }
}