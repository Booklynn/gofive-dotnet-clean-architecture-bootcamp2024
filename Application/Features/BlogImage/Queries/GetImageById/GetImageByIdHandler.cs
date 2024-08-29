using Application.Contracts.Persistence;
using Application.Models.BlogImage;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogImage.Queries.GetImageById;

public class GetImageByIdHandler(IBlogImageRepository blogImageRepository, IMapper mapper) : IRequestHandler<GetImageByIdQuery, BlogImageDto>
{
    readonly IBlogImageRepository blogImageRepository = blogImageRepository;
    readonly IMapper mapper = mapper;

    public async Task<BlogImageDto> Handle(GetImageByIdQuery request, CancellationToken cancellationToken)
    {
        
        var image = await blogImageRepository.GetImageById(request.Id);
        return mapper.Map<BlogImageDto>(image);
    }
}
