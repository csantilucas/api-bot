using Microsoft.AspNetCore.Mvc;
using api_bot.Services;
using api_bot.models;

namespace api_bot.Controllers
{
    [ApiController]
    [Route("contrato/cliente")] 
    public class ContratoControler : ControllerBase
    {
        private readonly ContratoServiceImp _contratoService;

        
        public ContratoControler(ContratoServiceImp contratoService)
        {
            _contratoService = contratoService;
        }

        [HttpGet("{idCliente}")]
        public async Task<IActionResult> GetContratos(int idCliente)
        {
            try
            {
                var response = await _contratoService.BuscarPorIDAsync(idCliente);
                if (!response.ContratoEncontrado)
                {
                    return NotFound(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Sucesso = false, Mensagem = ex.Message });
            }
        }
    }
}