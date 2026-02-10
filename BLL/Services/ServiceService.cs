using BLL.Models;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class ServiceService : IServiceService
    {
        private readonly AppDbContext _context;

        public ServiceService(AppDbContext context) 
        {
            _context = context;
        }
        public async Task AddServiceAsync(Service service)
        {
            _context.Services.Add(MapToEntity(service));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
        }

        public Task<Service> GetServiceByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Service>> GetServicesByProviderAsync(int providerId)
        {
            var entities = await Task.Run(() =>
                                            _context.Services
                                                .Where(s => s.ProviderId == providerId)
                                                .ToList());


            return entities.Select(e => MapToModel(e)).ToList();
           
        }

        public void UpdateServiceAsync(Service service)
        {

            var existingEntity = _context.Services.Find(service.Id);
            if (existingEntity != null) 
            {
                existingEntity.Name = service.Name;
                existingEntity.Description = service.Description;
                existingEntity.Price = service.Price;
                existingEntity.Duration = service.Duration;

                _context.SaveChanges(); 
            }
        }

        private Service MapToModel(ServiceEntity entity)
        {
            return new Service
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                Duration = entity.Duration,
                ProviderId = entity.ProviderId
            };
        }

        private ServiceEntity MapToEntity(Service service)
        {
            return new ServiceEntity
            {
                Name = service.Name,
                Description = service.Description,
                Price = service.Price,
                Duration = service.Duration,
                ProviderId = service.ProviderId
            };
        }

        public List<Service> GetServicesByProvider(int providerId)
        {
           var entities =  _context.Services
                .Where(s => s.ProviderId == providerId)
                .ToList();
            return entities.Select(e => MapToModel(e)).ToList();
        }
    }
}
