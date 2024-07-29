using Application.Services;
using HardwareStock.Core.Application.Interfaces.Repositories;
using HardwareStock.Core.Application.Interfaces.Services;
using HardwareStock.Core.Application.ViewModels.Products;
using HardwareStock.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace HardwareStock.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _productService.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {
            SaveProductViewModel vm = new();
            vm.Categories = await _categoryService.GetAllViewModel(); 
            return View("SaProduct", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categories = await _categoryService.GetAllViewModel();
                View("SaveProduct", vm);
            }

            await _productService.Add(vm);
            return RedirectToRoute(new {Controller="Product",action="Index"});
        }
		public async Task<IActionResult> Edit(int id)
		{
            SaveProductViewModel vm = await _productService.GetByIdSaveViewModel(id);
            vm.Categories = await _categoryService.GetAllViewModel();
            return View("SaveProduct", vm);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(SaveProductViewModel vm)
		{
			if (!ModelState.IsValid)
			{
                vm.Categories = await _categoryService.GetAllViewModel();
                View("SaveProduct", vm);
			}

			await _productService.Update(vm);
			return RedirectToRoute(new { Controller = "Product", action = "Index" });
		}
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _productService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _productService.Delete(id);
            return RedirectToRoute(new { Controller = "Product", action = "Index" });
        }
    }
}
