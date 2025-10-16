using System.ComponentModel.DataAnnotations;

namespace SimpleMarketApp.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0.01, 10000)]
        public decimal Price { get; set; }
    }
}