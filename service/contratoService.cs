using api_bot.Data;
using api_bot.models;
using Microsoft.EntityFrameworkCore;

namespace api_bot.Services
{
    public class ContratoService : ContratoServiceImp
    {
        private readonly AppDbContext _context;

        public ContratoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ContratoResponse> BuscarPorIDAsync(int client_id)
        {
            
            var dadosContratos = await _context.ALPHA_SETOR_CONTRATOS
                .AsNoTracking()
                .Include(c => c.Cliente)
                .Where(c => c.ID_CLIENTE == client_id)
                .OrderByDescending(v => v.DATA_VALIDADE)
                .Select(c => new ContratoDto 
                {
                    number = c.NUMERO_CONTRATO,
                    dt_validade = c.DATA_VALIDADE,
                })
                .ToListAsync(); 

            if (dadosContratos == null || !dadosContratos.Any())
            {
                return new ContratoResponse
                {
                    Sucesso = true,
                    ContratoEncontrado = false,
                    Mensagem = "Nenhum contrato encontrado.",
                    Contratos = new List<ContratoDto>()
                };
            }

            return new ContratoResponse
            {
                Sucesso = true,
                ContratoEncontrado = true,
                Mensagem = "Contratos localizados com sucesso.",
                Contratos = dadosContratos 
            };
        }
    }
}