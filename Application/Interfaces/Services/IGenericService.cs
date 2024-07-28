using HardwareStock.Core.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStock.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveViewModel, ViewModel> 
        where SaveViewModel : class
        where ViewModel : class
    {
        Task Update(SaveViewModel vm);
        Task Delete(int id);
        Task Add(SaveViewModel vm);
        Task<SaveViewModel> GetByIdSaveViewModel(int id);
        Task<List<ViewModel>> GetAllViewModel();
    }
}
