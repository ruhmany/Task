using Domain.DTO.CategoryDTOs;
using Domain.DTO.ProductDTOs;
using Domain.Models;
using IRepositories.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class TaskFacade
    {
        private readonly ICategoryRepo _categoryRepo;
        public TaskFacade(ICategoryRepo categoryRepo, IProductRepo productRepo)
        {
            _categoryRepo = categoryRepo;

        }
        public async Task<Category> getCategoryByName(string Name)
        {
            return await _categoryRepo.FindByName(Name);
        }

        public async Task<IEnumerable<ProductByCategoryIdDTO>> GetProductsByCategoryID(int id)
        {
            return await _categoryRepo.GetProducts(id);
        }

    }
}
