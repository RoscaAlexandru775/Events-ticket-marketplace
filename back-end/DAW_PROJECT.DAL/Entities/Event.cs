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
    public class Event:IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Denumire { get; set; }
        [Required]
        public string ZiDesfasurare { get; set; }
        [Required]
        public int Pret { get; set; }
        [Required]
        public int NumarBilete { get; set; }
        [Required]
        public string Categorie { get; set; }
        [Required]
        public int? OrganizatorId { get; set; }
      
        public  virtual Organizer OrganizerEvent { get; set; }
        [JsonIgnore]
        public List<Location> Locations { get; set; }
       
    }
}
