
namespace BLL.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public string? Category { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; } // Для отображения в UI

        public List<string> Categories { get; set; } = new List<string>
        {
            "УБОРКА И КЛИНИНГ",
            "РЕМОНТ И ОБСЛУЖИВАНИЕ",
            "КОМПЬЮТЕРНАЯ ПОМОЩЬ",
            "РЕМОНТНЫЕ РАБОТЫ",
            "УХОД ЗА РАСТЕНИЯМИ",
            "ПЕРЕЕЗД И ГРУЗОПЕРЕВОЗКИ",
            "БЫТОВАЯ ПОМОЩЬ И УХОД"
        };
    }
}
