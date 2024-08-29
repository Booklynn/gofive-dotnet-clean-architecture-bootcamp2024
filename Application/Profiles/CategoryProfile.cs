using Application.Models.Category;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class CategoryProfile : Profile 
    {
        public CategoryProfile() 
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<CreateCategoryRequestDto, Category>();

            CreateMap<UpdateCategoryRequestDto, Category>();
        }
    }
}
