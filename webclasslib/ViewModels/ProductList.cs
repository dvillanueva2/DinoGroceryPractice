using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ViewModels
{
    public class ProductList
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string UnitSize { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } // container for Category's Description row data
        public bool Taxable { get; set; }
        public byte[]? Photo { get; set; }
    }
}