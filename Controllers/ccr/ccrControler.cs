
using Microsoft.AspNetCore.Mvc;
using api_bot.Services; 



namespace api_bot.Controllers
{
    [ApiController]
[Route("ccr/cliente")]
public class CcrControler : ControllerBase 
{
    private readonly CcrServiceImp _ccrservice;

    public CcrControler(CcrServiceImp ccrService) 
{

    _ccrservice = ccrService;
}

        [HttpGet("{idCliente}/{limit}")]
        public async Task<IActionResult> GetCcr (int idCliente, int limit)
        {
            
            var fatura = await _ccrservice.BuscarPorIDAsync(idCliente, limit);
            
            if (fatura == null)
                return NotFound($"Nenhum  encontrada para o ID {idCliente}.");

            return Ok(fatura);
        }

       
}
}