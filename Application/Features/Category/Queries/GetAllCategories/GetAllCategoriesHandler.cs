using Application.Contracts.Persistence;
using Application.Models.Category;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetAllCategories;

public class GetAllCategoriesHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    readonly ICategoryRepository _categoryRepository = categoryRepository;
    readonly IMapper _mapper = mapper;

    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllCategories();
        
        return _mapper.Map<List<CategoryDto>>(categories);
    }
}
