using APISolution.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APISolution.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Email { get; set; }
        public ICollection<PolicyCustomer> PolicyCustomers { get; set; }
    }
}
