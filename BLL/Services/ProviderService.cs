using BLL.Models;
using DAL.Context;
using DAL.Entities;

namespace BLL.Services
{
    public class ProviderService : IProviderService
    {
        private readonly AppDbContext _context;

        public ProviderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddProviderAsync(Provider provider)
        {
            _context.Providers.Add(MapToEntity(provider));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProviderAsync(int id)
        {
            var provider = await _context.Providers.FindAsync(id);

            if (provider != null)
            {
                _context.Providers.Remove(provider);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Provider>> GetAllProvidersAsync()
        {
            List<ProviderEntity> entities = _context.Providers.ToList();
            return entities.Select(e => MapToModel(e)).ToList();
        }


        public Task<Provider> GetProviderByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProviderAsync(Provider provider)
        {
            var existingEntity = _context.Providers.Find(provider.Id);
            if (existingEntity != null)
            {
                existingEntity.Id = provider.Id;
                existingEntity.Name = provider.Name;
                existingEntity.Phone = provider.Phone;
                existingEntity.Address = provider.Address;

                _context.SaveChanges();
            }
        }

        private Provider MapToModel(ProviderEntity entity)
        {
            return new Provider
            {
                Id = entity.Id,
                Name = entity.Name,
                Phone = entity.Phone,
                Address = entity.Address
            };
        }

        private ProviderEntity MapToEntity(Provider provider)
        {
            return new ProviderEntity
            {
                Id = provider.Id,
                Name = provider.Name,
                Phone = provider.Phone,
                Address = provider.Address
            };
        }
    }
}
