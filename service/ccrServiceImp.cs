using api_bot.models;


namespace api_bot.Services
{
    public interface CcrServiceImp
    {
        Task<CcrResponde> BuscarPorIDAsync(int client_id, int limit);

    }
}
