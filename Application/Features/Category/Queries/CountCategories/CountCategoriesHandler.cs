using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.Category.Queries.CountCategories;

public class CountCategoriesHandler(ICategoryRepository categoryRepository) : IRequestHandler<CountCategoriesQuery, int>
{
    readonly ICategoryRepository categoryRepository = categoryRepository;

    public async Task<int> Handle(CountCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await categoryRepository.CountCategories();
    }
}
