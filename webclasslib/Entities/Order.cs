using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderLists = new HashSet<OrderList>();
        }

        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        [Column("StoreID")]
        public int StoreId { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("PickerID")]
        public int? PickerId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RequiredBy { get; set; }
        public bool Delivery { get; set; }
        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }
        [Column("GST", TypeName = "money")]
        public decimal Gst { get; set; }
        /// <summary>
        /// **N**ew Order Placed, **A**ssigned to Picker, **R**ready (Picked), **O**ut on Delivery, **D**elivered, **P**icked up by Customer
        /// </summary>
        [Required]
        [StringLength(1)]
        [Unicode(false)]
        public string Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastStatusUpdate { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(StoreId))]
        [InverseProperty("Orders")]
        public virtual Store Store { get; set; }
        [InverseProperty(nameof(OrderList.Order))]
        public virtual ICollection<OrderList> OrderLists { get; set; }
    }
}
