using Application.Services;
using HardwareStock.Core.Application.Interfaces.Services;
using HardwareStock.Core.Application.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.HardwareStock.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _categoryService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveCategory", new SaveCategoryViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveCategoryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                View("SaveCategory", vm);
            }

            await _categoryService.Add(vm);
            return RedirectToRoute(new { Controller = "Category", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveCategory", await _categoryService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveCategoryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                View("SaveCategory", vm);
            }

            await _categoryService.Update(vm);
            return RedirectToRoute(new { Controller = "Category", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _categoryService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _categoryService.Delete(id);
            return RedirectToRoute(new { Controller = "Category", action = "Index" });
        }
    }
}
