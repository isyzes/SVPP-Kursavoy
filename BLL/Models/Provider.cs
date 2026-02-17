
namespace BLL.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
        public int Rating { get; set; }
        public string DisplayLogo => string.IsNullOrEmpty(Logo) ? "/images/noLogo.png" : Logo;
    }
}
