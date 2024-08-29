using Application.Contracts.Persistence;
using Application.Models.Category;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<UpdateCategoryCommand, CategoryDto>
{
    private readonly ICategoryRepository categoryRepository = categoryRepository;
    private readonly IMapper mapper = mapper;

    public async Task<CategoryDto> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var categoryUpdateModel = mapper.Map<Domain.Entities.Category>(command.Request);
        categoryUpdateModel.Id = command.Id;

        var result = await categoryRepository.UpdateCategory(categoryUpdateModel);

        return mapper.Map<CategoryDto>(result);
    }
}
