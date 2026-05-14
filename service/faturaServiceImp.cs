using api_bot.models;


namespace api_bot.Services
{
    public interface FaturaServiceImp
    {
        Task<FaturaResponse> BuscarPorIDAsync(int client_id);
        Task<FaturaPDFResponse> BuscarPDFAsync(int fature_id);
    }
}
