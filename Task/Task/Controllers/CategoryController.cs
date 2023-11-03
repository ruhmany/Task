using Domain.DTO.CategoryDTOs;
using Domain.Models;
using IRepositories.IRepos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repos;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            
            var result = await _categoryRepo.GetAll();
            if(result == null)
            {
                return BadRequest(new { Message = "No categories"});
            }
            return Ok(result);
        }

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _categoryRepo.GetByID(id);
            if (result == null)
            {
                return BadRequest(new { Message = "No product with this ID"});
            }
            return Ok(result);
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _categoryRepo.GetProducts(id);
            if (result == null)
            {
                return BadRequest(new { Message = "This category doesn't have products"});
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryDTO addCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _categoryRepo.AddCategory(addCategoryDTO);
            if (result == null)
            {
                return BadRequest(new { Message = "Something went wrong while adding this category"});
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDTO updateCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _categoryRepo.Update(updateCategoryDTO);
            if (result == null)
            {
                return BadRequest(new { Message = "Something went wrong while updating this category" });
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _categoryRepo.Remove(id);
            if (result == null)
            {
                return BadRequest(new { Message = "Something went wrong while removing this category" });
            }
            return Ok(result);
        }
    }
}
