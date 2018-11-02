using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.Models
{
    [Table("Catategory")]
    public partial class Catategory
    {
        public Catategory()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("CatID")]
        [StringLength(2)]
        public string CatId { get; set; }
        [StringLength(50)]
        public string NameCat { get; set; }

        [InverseProperty("Cat")]
        public ICollection<Product> Products { get; set; }
    }
}
