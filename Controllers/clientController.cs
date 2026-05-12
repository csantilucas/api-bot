using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_bot.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_bot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class clientController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public clientController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost("buscar")]
        public async Task<IActionResult> BuscarPorCpf([FromBody] models.BuscaRequest request)
        {
            if (string.IsNullOrEmpty(request.Documento))
            {
                return BadRequest("O número do documento deve ser informado.");
            }

           
            var cliente = await _appDbContext.PESSOA
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CPF == request.Documento);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado com este CPF.");
            }

            return Ok(cliente);
        }
    }
}