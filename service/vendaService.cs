using api_bot.Data;
using api_bot.models; // Onde está a classe Movim e Client
using Microsoft.EntityFrameworkCore;


namespace api_bot.Services
{
    public class VendaService
    {
        private readonly AppDbContext _context;

        public VendaService(AppDbContext context)
        {
            _context = context;
        }

       public async Task<List<ClientDebtDto>> ObterVendasPorIdAsync(int idCliente, int quantidade)
            {
                return await _context.MOVIM
                    .AsNoTracking()
                    .Where(v => v.ID_CLIENTE == idCliente 
                    
                            && v.APLICACAO == 1 
                            && v.CANCELADA == 0
                            && v.TIPOMOV == 1)
                    // Pega os mais recentes
                    .OrderByDescending(v => v.DT_ENTREGA)
                    .Take(quantidade) 
                    .Select(v => new ClientDebtDto
                    {   
                        numeroVenda = v.NUMBER,
                        Data = v.DT_ENTREGA,
                        // Cálculo do TOTAL_GERAL (mesma lógica do seu SQL)
                        Valor = v.TOTAL + v.RECEBIDO + 
                                (v.TOTAL < v.VR_CREDITO ? v.VR_CREDITO : 0) + 
                                (v.TOTAL < v.VR_DEVOLUCAO ? v.VR_DEVOLUCAO : 0)
                    })
                    .ToListAsync();
            }

        public async Task<ClientDebtDto> ObterDadosVendaPorId(int idVenda, int idCliente)
            {
                return await _context.MOVIM
                    .AsNoTracking()
                    .Where(v => v.NUMBER == idVenda 
                            && v.ID_CLIENTE == idCliente 
                            && v.APLICACAO == 1 
                            && v.CANCELADA == 0
                            && v.TIPOMOV == 1)
                    .OrderByDescending(v => v.DT_ENTREGA)
                    .Select(v => new ClientDebtDto
                    {
                        numeroVenda = v.NUMBER,
                        Data = v.DT_ENTREGA,
                        Valor = v.TOTAL + v.RECEBIDO + 
                                (v.TOTAL < v.VR_CREDITO ? v.VR_CREDITO : 0) + 
                                (v.TOTAL < v.VR_DEVOLUCAO ? v.VR_DEVOLUCAO : 0)
                    })
                    .FirstOrDefaultAsync();
            }
    }
}