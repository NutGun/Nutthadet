using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.Models
{
    [Table("Titel")]
    public partial class Titel
    {
        public Titel()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        [StringLength(2)]
        public string InitialCode { get; set; }
        [Column("initialName")]
        [StringLength(50)]
        public string InitialName { get; set; }

        [InverseProperty("InitialCodeNavigation")]
        public ICollection<Customer> Customers { get; set; }
    }
}
