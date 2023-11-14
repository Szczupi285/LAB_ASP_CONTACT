using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("contacts")]
    public class ContactEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string? Phone { get; set; }
        [Required]
        public DateTime Birth {get; set;}

        public OrganizationEntity? Organization { get; set; }

        public int? OrganizationId { get; set; }
    }

}
