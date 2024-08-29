using Application.Models.Category;
using MediatR;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<CategoryDto>
{
    public Guid Id { get; set; }
    public UpdateCategoryRequestDto Request { get; set; }
}
