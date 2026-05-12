using api_bot.models;
using api_bot.Data;


using Microsoft.EntityFrameworkCore;


namespace api_bot.Services
{
    public class ClientService : ClientServiceImp
    {
        private readonly AppDbContext _context;

        public ClientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ClienteResponse> BuscarPorCpfAsync(string documento)
        {
            var cliente = await _context.PESSOA
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CPF == documento);

            if (cliente == null)
            {
                return new ClienteResponse 
                { 
                    Sucesso = true, 
                    ClienteEncontrado = false, 
                    Mensagem = "Nenhum cliente localizado." 
                };
            }

            return new ClienteResponse
            {
                Sucesso = true,
                ClienteEncontrado = true,
                Mensagem = "Identificação realizada com sucesso.",
                Client = new ClientDto
                {
                    idCliente = cliente.ID_CLIENTE,
                    nomeResponsavel = cliente.NM_CONTATO,
                    empresa = cliente.NOME,
                    cidade = cliente.CIDADE,
                    bloqueado = cliente.BLOQUEA,
                    Inativo = cliente.INATIVO,
                    cpfresponsavel = cliente.CPF_CONTATO,
                    email = cliente.EMAIL
                  
                }
            };
        }
    }
}