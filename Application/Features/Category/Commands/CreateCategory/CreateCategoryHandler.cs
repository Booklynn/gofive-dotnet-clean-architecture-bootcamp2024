using Application.Contracts.Persistence;
using Application.Models.Category;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<CreateCategoryCommand, CategoryDto> 
{
    private readonly ICategoryRepository categoryRepository = categoryRepository;
    private readonly IMapper mapper = mapper;

    public async Task<CategoryDto> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var categoryCreateModel = mapper.Map<Domain.Entities.Category>(command.Request);
        var result = await categoryRepository.CreateCategory(categoryCreateModel);

        return mapper.Map<CategoryDto>(result);
    }
}
