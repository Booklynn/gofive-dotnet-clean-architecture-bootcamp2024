using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.DeleteCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Category.Queries.CountCategories;
using Application.Features.Category.Queries.GetAllCategories;
using Application.Features.Category.Queries.GetCategoryById;
using Application.Models.Category;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IMediator mediator) : ControllerBase 
    {
        readonly IMediator mediator = mediator;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id) 
        {
            var result = await mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories() 
        {
            var categories = await mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto request)
        {
            var command = new CreateCategoryCommand
            {
                Request = request
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] UpdateCategoryRequestDto request)
        {
            var command = new UpdateCategoryCommand
            {
                Id = id,
                Request = request
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var command = new DeleteCategoryCommand     
            {
                Id = id
            };
        
            await mediator.Send(command);
            return Ok();
        }

        [HttpGet("total")]
        public async Task<IActionResult> CountCategories()
        {
            var categories = await mediator.Send(new CountCategoriesQuery());
            return Ok(categories);
        }
    }
}
