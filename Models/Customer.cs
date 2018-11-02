using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.Models
{
    [Table("Customer")]
    public partial class Customer
    {
        [Key]
        [StringLength(5)]
        public string CustId { get; set; }
        [StringLength(2)]
        public string InitialCode { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Lastname { get; set; }
        [StringLength(2)]
        public string CustType { get; set; }

        [ForeignKey("CustType")]
        [InverseProperty("Customers")]
        public Type CustTypeNavigation { get; set; }
        [ForeignKey("InitialCode")]
        [InverseProperty("Customers")]
        public Titel InitialCodeNavigation { get; set; }
    }
}
