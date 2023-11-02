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
        private readonly IBaseRepo<Product> _baserepo;

        public ProductController(TaskFacade taskFacade, IBaseRepo<Product> baseRepo, IBaseRepo<Product> baserepo)
        {
            _taskFacade = taskFacade;
            _baserepo = baserepo;
        }

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _baserepo.GetAsync(id);
            if (result == null)
            {
                return BadRequest(ModelState);
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
                return BadRequest(ModelState);
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
            var result = await _taskFacade.AddProduct(addProductDTO, category);
            if (result == null)
            {
                return BadRequest(result);
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
            var result = await _taskFacade.UpdateProduct(updateProductDTO);
            if (result == null)
            {
                return BadRequest(ModelState);
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
            var result = await _taskFacade.RemoveProduct(id);
            if(result == null)
            {
                return BadRequest(ModelState);
            }
            return Ok(result);
        }
    }
}
