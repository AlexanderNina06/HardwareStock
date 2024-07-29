using HardwareStock.Core.Application.Interfaces.Repositories;
using HardwareStock.Core.Application.Interfaces.Services;
using HardwareStock.Core.Application.ViewModels.Categories;
using HardwareStock.Core.Domain.Entities;


namespace HardwareStock.Core.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryViewModel>> GetAllViewModel()
        {
            var CategoryList = await _categoryRepository.GetAllWithIncludeAsync(new List<string> {"Products"});

            return CategoryList.Select(category => new CategoryViewModel
            {
                Name = category.Name,
                Id = category.Id,
                Image = category.Image,
                ProductCount = category.Products.Count()

            }).ToList();
        }
        public async Task<SaveCategoryViewModel> GetByIdSaveViewModel(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            SaveCategoryViewModel vm = new();
            vm.Id = category.Id;
            vm.Name = category.Name;
            vm.Image = category.Image;

            return vm;
        }

        public async Task Add(SaveCategoryViewModel vm)
        {
            Category category = new();
            category.Name = vm.Name;
            category.Image = vm.Image;
            Category category2 = new();

            await _categoryRepository.AddAsync(category2);
        }
        public async Task Update(SaveCategoryViewModel vm)
        {
            Category category = new();
            category.Name = vm.Name;
            category.Id = vm.Id;
            category.Image = vm.Image;

            await _categoryRepository.UpdateAsync(category);
        }
        public async Task Delete(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);

            await _categoryRepository.DeleteAsync(category);
        }
    }
}
