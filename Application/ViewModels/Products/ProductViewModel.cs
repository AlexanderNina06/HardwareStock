﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStock.Core.Application.ViewModels.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int Quantity { get; set; }
        public string? CategoryName { get; set; }

    }
}
