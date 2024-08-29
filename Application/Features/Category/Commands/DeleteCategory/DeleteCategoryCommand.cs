using Application.Models.Category;
using MediatR;

namespace Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<CategoryDto>
{
    public Guid Id { get; set; }
}
