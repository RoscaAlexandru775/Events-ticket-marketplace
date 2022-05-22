using DAW_PROJECT.DAL.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAW_PROJECT.DAL.Entities
{
    public class Organizer : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [JsonIgnore]
        public virtual Event EventOrganizer { get; set; }
    }
}
