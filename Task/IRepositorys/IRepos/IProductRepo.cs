using Domain.DTO.ProductDTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories.IRepos
{
    public interface IProductRepo : IBaseRepo<Product>
    {
        Task<Product> AddProduct(AddProductDTO addProductDTO, Category? category);
        Task<Product> Update(UpdateProductDTO updateProductDTO);
        Task<Product> Remove(int id);
    }
}
