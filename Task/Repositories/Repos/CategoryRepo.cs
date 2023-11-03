using Domain.DTO.CategoryDTOs;
using Domain.DTO.ProductDTOs;
using Domain.Models;
using IRepositories.IRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryRepo(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Category> FindByName(string Name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == Name);
            if (category == null)
            {
                var ctg = new AddCategoryDTO()
                {
                    CategoryName = Name
                };
                var result = await AddCategory(ctg);
                category = new Category { Name = result.Name, ID = result.ID };

            }
            return category;
        }

        public async Task<AddCategoryResponseDTO> AddCategory(AddCategoryDTO addCategoryDTO)
        {
            var category = new Category()
            {
                Name = addCategoryDTO.CategoryName
            };
            var x = await _context.Categories.AddAsync(category);
            if(x.State == EntityState.Added)
            {
                _unitOfWork.CommitChanges();
                var result = new AddCategoryResponseDTO { ID = x.Entity.ID, Name=x.Entity.Name};
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<AddCategoryResponseDTO>> GetAll()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            var result = new List<AddCategoryResponseDTO>();
            foreach (var category in categories)
            {
                result.Add(new AddCategoryResponseDTO { ID = category.ID, Name = category.Name });
            }
            return result;
        }

        public async Task<AddCategoryResponseDTO> GetByID(int id)
        {
            var result = await _context.Categories.FindAsync(id);
            return new AddCategoryResponseDTO() { Name = result.Name, ID = result.ID };
        }

        public async Task<IEnumerable<ProductByCategoryIdDTO>> GetProducts(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null)
            {
                return Enumerable.Empty<ProductByCategoryIdDTO>();
            }
            var result = new List<ProductByCategoryIdDTO>();
            foreach (var item in category.Products)
                result.Add(new ProductByCategoryIdDTO() { Name = item.Name, ID = item.ID });
            return result;
        }

        public async Task<AddCategoryResponseDTO> Remove(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            _context.Categories.Remove(category);
            _unitOfWork.CommitChanges();
            return new AddCategoryResponseDTO { ID = category.ID, Name = category.Name};
        }

        public async Task<AddCategoryResponseDTO> Update(UpdateCategoryDTO updateCategoryDTO)
        {
            var category = await _context.Categories.FindAsync(updateCategoryDTO.CategoryID);
            if (category == null)
                return null;
            category.Name = updateCategoryDTO.CategoryName;
            _context.Categories.Update(category);
            _unitOfWork.CommitChanges();
            return new AddCategoryResponseDTO { ID = category.ID, Name = category.Name};
        }
    }
}
