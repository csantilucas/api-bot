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
                            id_boleto =v.ID_BOLETO_GERADO,
                            dt_fechamento = v.DT_VENCIMENTO,
                            vlr_bol = v.VALOR_BOLETO,
                            linha_dgt = v.LINHA_DIGITAVEL
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

        public async Task<FaturaPDFResponse> BuscarPDFAsync(int fatura_id)
{
    var dadosFatura = await _context.boleto_gerado
        .AsNoTracking()
        // Filtramos diretamente pelo ID primário
        .Where(v => v.ID_BOLETO_GERADO == fatura_id
                && v.id_receber > 0
                && v.boleto_pago == 0
                && v.pedido_baixa == 0)
        .Select(v => new FaturaDbtDto
        {
            num_bol = v.id_receber,
            dt_fechamento = v.DT_VENCIMENTO,
            id_boleto = v.ID_BOLETO_GERADO,
            vlr_bol = v.VALOR_BOLETO,
            linha_dgt = v.LINHA_DIGITAVEL,
            boleto_pago = v.boleto_pago
        })
        .FirstOrDefaultAsync(); 

    if (dadosFatura == null)
    {
        return new FaturaPDFResponse
        {
            Sucesso = true, 
            BoletosEncontrado = false,
            Mensagem = "Boleto não encontrado ou já foi baixado.",
            fatura = null
        };
    }

    return new FaturaPDFResponse
    {
        Sucesso = true,
        BoletosEncontrado = true,
        Mensagem = "Boleto localizado com sucesso.",
        fatura = dadosFatura
    };
}
    }
}