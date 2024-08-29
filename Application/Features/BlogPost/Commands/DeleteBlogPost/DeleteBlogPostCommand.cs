using System;
using Application.Models.BlogPost;
using MediatR;

namespace Application.Features.BlogPost.Commands.DeleteBlogPost;

public class DeleteBlogPostCommand(Guid id) : IRequest<BlogPostDto>
{
    public Guid Id { get; set; } = id;
}
