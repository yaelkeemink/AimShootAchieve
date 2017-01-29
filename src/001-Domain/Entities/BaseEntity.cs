using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        public bool Prive { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
