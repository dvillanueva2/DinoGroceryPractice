﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Order>();
            Pickers = new HashSet<Picker>();
        }

        [Key]
        [Column("StoreID")]
        public int StoreId { get; set; }
        [Required]
        [StringLength(50)]
        public string Location { get; set; }
        [Required]
        [StringLength(30)]
        public string Address { get; set; }
        [Required]
        [StringLength(30)]
        public string City { get; set; }
        [Required]
        [StringLength(2)]
        public string Province { get; set; }
        [Required]
        [StringLength(12)]
        public string Phone { get; set; }
        [Column("ManagerID")]
        public Guid? ManagerId { get; set; }
        [Column("AssistantManagerID")]
        public Guid? AssistantManagerId { get; set; }
        [Column(TypeName = "image")]
        public byte[] Map { get; set; }

        [InverseProperty(nameof(Order.Store))]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty(nameof(Picker.Store))]
        public virtual ICollection<Picker> Pickers { get; set; }
    }
}
