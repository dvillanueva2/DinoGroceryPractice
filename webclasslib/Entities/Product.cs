using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderLists = new HashSet<OrderList>();
        }

        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Column(TypeName = "money")]
        public decimal Discount { get; set; }
        [Required]
        [StringLength(20)]
        public string UnitSize { get; set; }
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        public bool Taxable { get; set; }
        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }
        [InverseProperty(nameof(OrderList.Product))]
        public virtual ICollection<OrderList> OrderLists { get; set; }
    }
}
