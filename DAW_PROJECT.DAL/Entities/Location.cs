using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_PROJECT.DAL.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
