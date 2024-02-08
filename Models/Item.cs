using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace yummer_backend.Models
{
    public class Item
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is mandatory.")]
        public string? Name { get; set; }
        
        [MaxLength(255)]
        public string? Description { get; set; }
        
        public double Price { get; set; }
    }
}