using HardwareStock.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardwareStock.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
           _productService = productService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _productService.GetAllViewModel());
        }

      
    }
}
