using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api_bot.Services; 
using api_bot.models;  
using api_bot.Services;

namespace api_bot.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class VendasController : ControllerBase
{
    private readonly VendaService _vendaService;

    public VendasController(VendaService vendaService)
    {
        _vendaService = vendaService;
    }

        [HttpGet("id/{idCliente}/{limite}")]
        public async Task<IActionResult> GetVendas(int idCliente, int limite)
        {
            // O Controller agora chama o nome correto do método que está no Service
            var vendas = await _vendaService.ObterVendasPorIdAsync(idCliente, limite);
            
            if (vendas == null || !vendas.Any())
                return NotFound($"Nenhuma venda encontrada para o ID {idCliente}.");

            return Ok(vendas);
        }

        [HttpGet("id/venda/{idvenda}/{idcliente}")]
        public async Task<IActionResult> GetVendaId(int idvenda, int idcliente) // Nomes idênticos aos da rota
        {
            var venda = await _vendaService.ObterDadosVendaPorId(idvenda, idcliente);

            if (venda == null)
                return NotFound($"Nenhuma venda número {idvenda} encontrada para o cliente {idcliente}.");

            return Ok(venda);
        }
}
}