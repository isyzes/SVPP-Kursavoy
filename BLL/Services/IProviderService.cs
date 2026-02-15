using BLL.Models;

namespace BLL.Services
{
    public interface IProviderService
    {
        Task<List<Provider>> GetAllProvidersAsync();
        List<Provider> GetAllProviders();
        Task AddProviderAsync(Provider provider);
        public void UpdateProviderAsync(Provider provider);
        Task DeleteProviderAsync(int id);
    }
}
