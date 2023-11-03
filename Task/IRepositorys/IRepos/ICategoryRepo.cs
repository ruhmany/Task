using Domain.DTO.CategoryDTOs;
using Domain.DTO.ProductDTOs;
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
        Task<AddCategoryResponseDTO> AddCategory(AddCategoryDTO addCategoryDTO);
        Task<IEnumerable<AddCategoryResponseDTO>> GetAll();
        Task<AddCategoryResponseDTO> GetByID(int id);
        Task<IEnumerable<ProductByCategoryIdDTO>> GetProducts(int id);
        Task<AddCategoryResponseDTO> Remove(int id);
        Task<AddCategoryResponseDTO> Update(UpdateCategoryDTO updateCategoryDTO);
        Task<Category> FindByName(string Name);
    }
}
