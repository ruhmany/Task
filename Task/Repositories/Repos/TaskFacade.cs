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
        private readonly IProductRepo _productRepo;
        public TaskFacade(ICategoryRepo categoryRepo, IProductRepo productRepo)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
        }
        public async Task<Category> AddCategory(AddCategoryDTO addCategoryDTO)
        {
            return await _categoryRepo.AddCategory(addCategoryDTO);
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepo.GetAllAsync();
        }


        public async Task<Category> getCategoryByName(string Name)
        {
            return await _categoryRepo.FindByName(Name);
        }

        public async Task<Category> GetCategoryByID(int id)
        {
            return await _categoryRepo.GetByID(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryID(int id)
        {
            return await _categoryRepo.GetProducts(id);
        }

        public async Task<Category> UpdaeCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            return await _categoryRepo.Update(updateCategoryDTO);
        }

        public async Task<Category> DeleteCategory(int id)
        {
            return await _categoryRepo.Remove(id);
        }

        /*-----------------------------------------------------------------*/

        public async Task<Product> AddProduct(AddProductDTO addProductDTO, Category? category)
        {
            return await _productRepo.AddProduct(addProductDTO, category);
        }

        public async Task<Product> RemoveProduct(int id)
        {
            return await _productRepo.Remove(id);
        }

        public async Task<Product> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            return await _productRepo.Update(updateProductDTO);
        }

    }
}
