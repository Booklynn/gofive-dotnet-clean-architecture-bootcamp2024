using Application.Models.BlogPost;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class BlogPostProfile : Profile
{
    public BlogPostProfile()
    {
        CreateMap<BlogPost, BlogPostDto>();
        
        CreateMap<CreateBlogPostRequestDto, BlogPost>()
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => new List<Category>()));
        
        CreateMap<UpdateBlogPostRequestDto, BlogPost>()
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => new List<Category>()));
    }
}
