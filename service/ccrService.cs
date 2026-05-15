using api_bot.Data;
using api_bot.models;
using Microsoft.EntityFrameworkCore;

namespace api_bot.Services{

public class CcrService : CcrServiceImp

    {
        private readonly AppDbContext _context;

        public CcrService(AppDbContext context)
        {
            _context = context;
        }
       public async Task<CcrResponde> BuscarPorIDAsync(int client_id, int limit)
{
    var dadosCcr = await _context.UPAG_SIAPE
        .AsNoTracking()
        .Include(c => c.Cliente)
        .Where(c => c.ID_CLIENTE == client_id 
                && c.COLETA_CCR_GUIDE != null
                && c.situacao > 0)
        .OrderByDescending(v => v.DATA_COLETA)
        .Take(limit)
        .Select(c => new CcrDto
        {
            dt_coleta = c.DATA_COLETA,
            quant_coleta = c.quantidade,
            
            link = $"https://documentos-alphasoftware.premiumasp.net/Coletas/B6B29824-F686-4382-9F5A-E3981A9A0A0C/{c.COLETA_CCR_GUIDE}/{c.Cliente.COLETA_GUIDE}"
        })
        .ToListAsync();

    
    if (dadosCcr == null || !dadosCcr.Any())
    {
        return new CcrResponde
        {
            Sucesso = true, 
            CcrEncontrado = false,
            Mensagem = "Nenhuma coleta encontrada para este cliente.",
            ccr = null
        };
    }

    return new CcrResponde
    {
        Sucesso = true,
        CcrEncontrado = true,
        Mensagem = $"{dadosCcr.Count} últimas coletas localizadas com sucesso.",
        ccr = dadosCcr
    };
}

     
    }
}