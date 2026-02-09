using BLL.Models;

namespace BLL.Services
{
    public interface IProviderService
    {
        Task<List<Provider>> GetAllProvidersAsync();
        Task<Provider> GetProviderByIdAsync(int id);
        Task AddProviderAsync(Provider provider);
        public void UpdateProviderAsync(Provider provider);
        Task DeleteProviderAsync(int id);
    }
}
