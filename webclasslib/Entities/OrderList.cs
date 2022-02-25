using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    [Table("OrderList")]
    public partial class OrderList
    {
        [Key]
        [Column("OrderListID")]
        public int OrderListId { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        public double QtyOrdered { get; set; }
        public double QtyPicked { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Column(TypeName = "money")]
        public decimal Discount { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string CustomerComment { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string PickIssue { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderLists")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderLists")]
        public virtual Product Product { get; set; }
    }
}
