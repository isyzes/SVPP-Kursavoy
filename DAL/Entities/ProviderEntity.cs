
namespace DAL.Entities
{
    public class ProviderEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public string? Logo { get; set; }
        public int Rating { get; set; }

        // Навигационное свойство для связи 1-ко-многим
        public virtual ICollection<ServiceEntity> Services { get; set; }
    }
}
