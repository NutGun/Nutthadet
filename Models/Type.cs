using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.Models
{
    [Table("Type")]
    public partial class Type
    {
        public Type()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        [Column("custType")]
        [StringLength(2)]
        public string CustType { get; set; }
        [StringLength(10)]
        public string NameType { get; set; }

        [InverseProperty("CustTypeNavigation")]
        public ICollection<Customer> Customers { get; set; }
    }
}
