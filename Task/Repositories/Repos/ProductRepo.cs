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
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public ProductRepo(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> AddProduct(AddProductDTO addProductDTO, Category? category)
        {
            var product = new Product();
            product.Name = addProductDTO.ProductName;
            if(category == null)
            {
                product.Categoty = new Category();
                product.Categoty.Name = addProductDTO.CategoryName;
                await _context.Products.AddAsync(product);
                _unitOfWork.CommitChanges();
            }
            product.Categoty = category;
            await _context.Products.AddAsync(product);
            _unitOfWork.CommitChanges();
            return product;
        }

        public async Task<Product> Remove(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                return null;
            }
            _context.Products.Remove(product);
            _unitOfWork.CommitChanges();
            return product;
        }

        public async Task<Product> Update(UpdateProductDTO updateProductDTO)
        {
            var Product = await _context.Products.FindAsync(updateProductDTO.ID);
            if(Product == null)
            {
                return null;
            }            
            Product.Categoty.Name = updateProductDTO.CategoryName;
            Product.Name = updateProductDTO.ProductName;
            Product.Price = updateProductDTO.Price;
            _context.Products.Update(Product);
            _unitOfWork.CommitChanges();
            return Product;

        }
    }
}
