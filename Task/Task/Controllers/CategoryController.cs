using Domain.DTO.CategoryDTOs;
using Domain.Models;
using IRepositories.IRepos;
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
        private readonly TaskFacade _taskFacade;
        private readonly IBaseRepo<Category> _baserepo;

        public CategoryController(TaskFacade taskFacade, IBaseRepo<Category> baserepo)
        {
            _taskFacade = taskFacade;
            _baserepo = baserepo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _baserepo.GetAllAsync();
            if(result == null)
            {
                return BadRequest(result);
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
            var result = await _taskFacade.GetCategoryByID(id);
            if (result == null)
            {
                return BadRequest(result);
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
            var result = await _taskFacade.GetProductsByCategoryID(id);
            if (result == null)
            {
                return BadRequest(result);
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
            var result = await _taskFacade.AddCategory(addCategoryDTO);
            if (result == null)
            {
                return BadRequest(result);
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
            var result = await _taskFacade.UpdaeCategory(updateCategoryDTO);
            if (result == null)
            {
                return BadRequest(result);
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
            var result = await _taskFacade.DeleteCategory(id);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
