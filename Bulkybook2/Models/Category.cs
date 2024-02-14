using System.ComponentModel.DataAnnotations;

namespace Bulkybook2.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Order { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

    }
}
