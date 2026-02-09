using BLL.Models;

namespace BLL.Services
{
    public interface IServiceService
    {
        Task<List<Service>> GetServicesByProviderAsync(int providerId);
        Task<Service> GetServiceByIdAsync(int id);
        Task AddServiceAsync(Service service);
        public void UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);
    }
}
