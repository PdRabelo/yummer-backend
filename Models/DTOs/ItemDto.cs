using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace yummer_backend.Models.DTOs
{
    public class ItemDto
    {
        [Required(ErrorMessage = "Name is mandatory.")]
        public string? Name { get; set; }
        
        [MaxLength(255)]
        public string? Description { get; set; }
        
        public double Price { get; set; }
        
    }
}