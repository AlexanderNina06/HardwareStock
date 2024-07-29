using HardwareStock.Core.Application.Interfaces.Repositories;
using HardwareStock.Core.Application.Interfaces.Services;
using HardwareStock.Core.Application.ViewModels.Products;
using HardwareStock.Core.Domain.Entities;

namespace Application.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductViewModel>> GetAllViewModel()
        {
            var ProductList = await _productRepository.GetAllWithIncludeAsync(new List<string> {"category"});

            return ProductList.Select(product => new ProductViewModel
            {
                Name = product.Name,
                Id = product.Id,
                Price = product.Price,
                Quantity = product.Quantity,
                CategoryName = product.category.Name

            }).ToList();
        }
		public async Task<SaveProductViewModel> GetByIdSaveViewModel(int id)
		{
			var Product = await _productRepository.GetByIdAsync(id);

            SaveProductViewModel vm = new();
            vm.Id = Product.Id;
            vm.Name = Product.Name; 
            vm.Price = Product.Price;   
            vm.Quantity = Product.Quantity;
            vm.CategoryId = Product.CategoryId;

            return vm;	
		}

		public async Task Add(SaveProductViewModel vm)
        {
            Product product = new();
            product.Name = vm.Name;
            product.Price = vm.Price;
            product.Quantity = vm.Quantity;
            product.CategoryId = vm.CategoryId;

            await _productRepository.AddAsync(product);
        }
		public async Task Update(SaveProductViewModel vm)
		{
			Product product = new();
			product.Name = vm.Name;
			product.Id = vm.Id;
			product.Price = vm.Price;
			product.Quantity = vm.Quantity;
			product.CategoryId = vm.CategoryId;

			await _productRepository.UpdateAsync(product);
		}
        public async Task Delete(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            
            await _productRepository.DeleteAsync(product);
        }


    }
}
