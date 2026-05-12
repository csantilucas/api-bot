using api_bot.models;


namespace api_bot.Services
{
    public interface ClientServiceImp
    {
        Task<ClienteResponse> BuscarPorCpfAsync(string documento);
    }
}
