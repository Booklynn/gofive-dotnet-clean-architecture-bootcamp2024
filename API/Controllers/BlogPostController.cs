using Application.Features.BlogPost.Commands.CreateBlogPost;
using Application.Features.BlogPost.Commands.DeleteBlogPost;
using Application.Features.BlogPost.Commands.UpdateBlogPost;
using Application.Features.BlogPost.Queries.CountBlogPosts;
using Application.Features.BlogPost.Queries.GetAllBlogPosts;
using Application.Features.BlogPost.Queries.GetBlogPostById;
using Application.Models.BlogPost;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController(IMediator mediator) : ControllerBase
    {
        readonly IMediator mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostRequestDto request)
        {
            var command = new CreateBlogPostCommand
            {
                Request = request
            };

            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var query = new GetAllBlogPostsQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPostById(Guid id)
        {
            var query = new GetBlogPostByIdQuery(id);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogPost(Guid id, [FromBody] UpdateBlogPostRequestDto request)
        {
            var command = new UpdateBlogPostCommand
            {
                Id = id,
                Request = request
            };

            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost(Guid id)
        {
            var command = new DeleteBlogPostCommand(id);
            await mediator.Send(command);

            return Ok();
        }

        [HttpGet("total")]
        public async Task<IActionResult> CountBlogPosts()
        {
            var query = new CountBlogPostsQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }
    }
}
