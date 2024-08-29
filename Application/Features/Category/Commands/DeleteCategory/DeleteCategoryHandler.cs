using Application.Contracts.Persistence;
using Application.Models.Category;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryHandler(ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryCommand, CategoryDto>
{
    readonly ICategoryRepository categoryRepository = categoryRepository;

    public async Task<CategoryDto> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        await categoryRepository.DeleteCategory(command.Id);
        return null;
    }
}
