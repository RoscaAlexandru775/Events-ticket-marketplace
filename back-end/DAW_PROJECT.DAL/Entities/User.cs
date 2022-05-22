using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAW_PROJECT.DAL.Entities
{
    public class User : IdentityUser<int>
    {

        public string RefreshToken { get; set;}
        public virtual ICollection<UserRole> UserRoles { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        [JsonIgnore]
        public List<Payment> Payments { get; set; }

    }
}
