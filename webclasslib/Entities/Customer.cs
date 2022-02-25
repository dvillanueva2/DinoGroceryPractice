using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(35)]
        public string LastName { get; set; }
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string Address { get; set; }
        [StringLength(10)]
        public string Unit { get; set; }
        [StringLength(30)]
        public string City { get; set; }
        [StringLength(2)]
        public string Province { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        [StringLength(40)]
        public string Email { get; set; }
        [Column("PreferredStoreID")]
        public int? PreferredStoreId { get; set; }

        [InverseProperty(nameof(Order.Customer))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
