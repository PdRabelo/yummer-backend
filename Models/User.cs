using Microsoft.AspNetCore.Identity;

namespace yummer_backend.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        
        //public Address
    }
}
