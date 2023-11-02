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
            return category;
        }

        public async Task<Category> AddCategory(AddCategoryDTO addCategoryDTO)
        {
            var category = new Category()
            {
                Name = addCategoryDTO.CategoryName
            };
            var x = await _context.Categories.AddAsync(category);
            if(x.State == EntityState.Added)
            {
                _unitOfWork.CommitChanges();
                return x.Entity;
            }
            return x.Entity;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByID(int id)
        {
            var result = await _context.Categories.FindAsync(id);
            return new Category() { Name = result.Name, ID = result.ID, Products = result.Products};
        }

        public async Task<IEnumerable<Product>> GetProducts(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null)
            {
                return Enumerable.Empty<Product>();
            }
            return category.Products;
        }

        public async Task<Category> Remove(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            _context.Categories.Remove(category);
            _unitOfWork.CommitChanges();
            return category;
        }

        public async Task<Category> Update(UpdateCategoryDTO updateCategoryDTO)
        {
            var category = await _context.Categories.FindAsync(updateCategoryDTO.CategoryID);
            if (category == null)
                return null;
            category.Name = updateCategoryDTO.CategoryName;
            _context.Categories.Update(category);
            _unitOfWork.CommitChanges();
            return category;
        }
    }
}
