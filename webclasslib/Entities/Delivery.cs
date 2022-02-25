﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public partial class Delivery
    {
        [Key]
        [Column("DeliveryID")]
        public int DeliveryId { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(12)]
        public string Phone { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DeliveredOn { get; set; }
        [StringLength(30)]
        public string Address { get; set; }
        [StringLength(10)]
        public string Unit { get; set; }
        [StringLength(30)]
        public string City { get; set; }
        [StringLength(2)]
        public string Province { get; set; }
    }
}
