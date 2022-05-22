using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_PROJECT.BLL.Models
{
    public class EventDto
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
    }
}
