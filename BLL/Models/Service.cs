
namespace BLL.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; } // Для отображения в UI
    }
}
