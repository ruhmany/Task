using Domain.DTO.CategoryDTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories.IRepos
{
    public interface ICategoryRepo : IBaseRepo<Category>
    {
        Task<Category> AddCategory(AddCategoryDTO addCategoryDTO);
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetByID(int id);
        Task<IEnumerable<Product>> GetProducts(int id);
        Task<Category> Remove(int id);
        Task<Category> Update(UpdateCategoryDTO updateCategoryDTO);
        Task<Category> FindByName(string Name);
    }
}
