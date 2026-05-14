using api_bot.Data;
using api_bot.models; 
using Microsoft.EntityFrameworkCore;


namespace api_bot.Services
{
    public class FaturaService : FaturaServiceImp
    {
        private readonly AppDbContext _context;
        

        public FaturaService(AppDbContext context)
        {
            _context = context;
        }

       
        public async Task<FaturaResponse> BuscarPorIDAsync(int idCliente)
{
    
    var dadosFatura = await _context.boleto_gerado
        .AsNoTracking()
        .Where(v => v.ID_CLIENTE == idCliente 
                 && v.id_receber > 0
                 && v.boleto_pago == 0
                 && v.pedido_baixa == 0) 
        .OrderBy(v => v.DT_VENCIMENTO)
        .Take(3)
        .Select(v => new FaturaDto
        {
            num_bol = v.id_receber,
            dt_fechamento = v.DT_VENCIMENTO,
            vlr_bol = v.VALOR_BOLETO
        })
        .ToListAsync();

            if (dadosFatura == null || !dadosFatura.Any())
            {
                return new FaturaResponse
                {
                    Sucesso = true, 
                    BoletosEncontrado = false,
                    Mensagem = "Nenhum boleto pendente encontrado para este cliente.",
                    fatura = null
                };
            }

            return new FaturaResponse
            {
                Sucesso = true,
                BoletosEncontrado = true,
                Mensagem = "3 ultimos boleto localizado com sucesso.",
                fatura = dadosFatura
            };
            
}
    }
}