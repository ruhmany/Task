using Domain.DTO.ProductDTOs;
using Domain.Models;
using IRepositories.IRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repos;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly TaskFacade _taskFacade;
        private readonly IProductRepo _productRepo;

        public ProductController(TaskFacade taskFacade, IProductRepo productRepo)
        {
            _taskFacade = taskFacade;
            _productRepo = productRepo;
        }

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productRepo.GetAsync(id);
            if (result == null)
            {
                return BadRequest(new { Message = "No product with this ID"});
            }
            return Ok(result);
        }
        [HttpGet("GetByCategoryID")]
        public async Task<IActionResult> GetByCategoryID(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _taskFacade.GetProductsByCategoryID(id);
            if (result == null)
            {
                return BadRequest(new { Message = "This Category Doesn't have product, or there is no category with this ID" });
            }
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddProductDTO addProductDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = await _taskFacade.getCategoryByName(addProductDTO.CategoryName);
            var result = await _productRepo.AddProduct(addProductDTO, category);
            if (result == null)
            {
                return BadRequest(new { Message = "Product didn't added"});
            }
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateProductDTO updateProductDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productRepo.Update(updateProductDTO);
            if (result == null)
            {
                return BadRequest(new { Message = "Something went wrong while updating this product"});
            }
            return Ok(result);
        }
        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productRepo.Remove(id);
            if(result == null)
            {
                return BadRequest(new { Message = "Something went wrong, Or now product with this ID"});
            }
            return Ok(result);
        }
    }
}
