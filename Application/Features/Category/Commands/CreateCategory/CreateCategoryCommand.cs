using Application.Models.Category;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<CategoryDto>
{
    public CreateCategoryRequestDto Request { get; set; }
}
