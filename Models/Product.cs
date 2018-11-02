using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.Models
{
    [Table("Product")]
    public partial class Product
    {
        [Key]
        [Column("code")]
        [StringLength(5)]
        public string Code { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; }
        [Column("price")]
        public double? Price { get; set; }
        [Column("unitPerPrice")]
        public double? UnitPerPrice { get; set; }
        [Column("qty")]
        [StringLength(50)]
        public string Qty { get; set; }
        [Column("status")]
        public short? Status { get; set; }
        [Column("unitCode")]
        [StringLength(2)]
        public string UnitCode { get; set; }
        [Column("CatID")]
        [StringLength(2)]
        public string CatId { get; set; }

        [ForeignKey("CatId")]
        [InverseProperty("Products")]
        public Catategory Cat { get; set; }
        [ForeignKey("UnitCode")]
        [InverseProperty("Products")]
        public Unit UnitCodeNavigation { get; set; }
    }
}
