
using Microsoft.AspNetCore.Mvc;
using api_bot.Services; 



namespace api_bot.Controllers
{
    [ApiController]
[Route("fatura")]
public class FaturaControler : ControllerBase
{
    private readonly FaturaServiceImp _faturaService;

    public FaturaControler(FaturaServiceImp faturaService) 
{

    _faturaService = faturaService;
}

        [HttpGet("{idCliente}")]
        public async Task<IActionResult> GetVendas(int idCliente)
        {
            // O Controller agora chama o nome correto do método que está no Service
            var fatura = await _faturaService.BuscarPorIDAsync(idCliente);
            
            if (fatura == null)
                return NotFound($"Nenhuma fatura encontrada para o ID {idCliente}.");

            return Ok(fatura);
        }

       
}
}