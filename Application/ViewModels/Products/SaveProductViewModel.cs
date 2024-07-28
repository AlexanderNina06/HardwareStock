using HardwareStock.Core.Application.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStock.Core.Application.ViewModels.Products
{
    public class SaveProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "debe colcar el nombre del producto")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "debe colcar el precio")]
        public double Price { get; set; }

        [Required(ErrorMessage = "debe colcar la cantidad")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "debe elegir una categoria")]
        public int CategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
