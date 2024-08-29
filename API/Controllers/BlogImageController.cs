using Application.Features.BlogImage.Commands.DeleteImage;
using Application.Features.BlogImage.Commands.UpdateImage;
using Application.Features.BlogImage.Commands.UploadImage;
using Application.Features.BlogImage.Queries.CountImages;
using Application.Features.BlogImage.Queries.GetAllImages;
using Application.Features.BlogImage.Queries.GetImageById;
using Application.Models.BlogImage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogImageController(IMediator mediator) : ControllerBase 
    {
        readonly IMediator mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] UploadImageRequestDto request) 
        {
            var result = await mediator.Send(new UploadImageCommand 
            { 
                Request = request
            });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(Guid id) 
        {
            await mediator.Send(new DeleteImageCommand(id));
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(Guid id) 
        {
            var result = await mediator.Send(new GetImageByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImages() 
        {
            var result = await mediator.Send(new GetAllImagesQuery());
            return Ok(result);
        }

        [HttpGet("total")]
        public async Task<IActionResult> CountImages() 
        {
            var result = await mediator.Send(new CountImagesQuery());
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImage([FromRoute] Guid id, [FromForm] UpdateImageRequestDto request) 
        {
            var result = await mediator.Send(new UpdateImageCommand 
            { 
                Id = id,
                Request = request
            });

            return Ok(result);
        }
    }
}
