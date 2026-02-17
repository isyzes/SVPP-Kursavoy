
namespace DAL.Entities
{
    public class ServiceEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; } // в минутах
        public string? Category { get; set; }
        public int ProviderId { get; set; }

        // Навигационное свойство
        public virtual ProviderEntity Provider { get; set; }
    }
}
