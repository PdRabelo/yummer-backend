using Microsoft.AspNetCore.Identity;

namespace yummer_backend.Models
{
    public class User : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        
        //public Address
    }
}
