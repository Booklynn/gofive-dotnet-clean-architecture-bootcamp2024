using Application.Models.Category;
using MediatR;

namespace Application.Features.Category.Queries.GetCategoryById;

public class GetCategoryByIdQuery(Guid id) : IRequest<CategoryDto>
{
    public Guid Id { get; set; } = id;
}
