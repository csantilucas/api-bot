using api_bot.models;


namespace api_bot.Services
{
    public interface ContratoServiceImp
    {
        Task<ContratoResponse> BuscarPorIDAsync(int client_id);

    }
}
