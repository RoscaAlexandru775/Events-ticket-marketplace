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
    public class Payment:IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CreditPay { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public int CVV { get; set; }
        [Required]
        public string ExpireDate { get; set; }
        [Required]
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
