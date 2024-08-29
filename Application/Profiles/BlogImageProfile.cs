using Application.Models.BlogImage;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class BlogImageProfile : Profile
{
    public BlogImageProfile()
    {
        CreateMap<BlogImage, BlogImageDto>();
        CreateMap<UploadImageRequestDto, BlogImage>();
        CreateMap<UpdateImageRequestDto, BlogImage>();
    }

}
