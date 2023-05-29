using Shop.Application.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure.Specifications;

public static class SpecificationEvaluator<T> where T : class
{
    public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> specification)
    {
        if (specification is not null)
        {
            _ = query.Where(specification.Requirement!);
        }

        if (specification!.OrderBy is not null)
        {
            _ = query.OrderBy(specification.OrderBy);
        }

        if (specification!.OrderByDescending is not null)
        {
            _ = query.OrderBy(specification.OrderByDescending);
        }

        if (specification.IsPagingEnable)
        {
            _ = query.Take(specification.Skip..specification.Take);
        }

        return specification.Includes!.Aggregate(
            query,
            (current, include) => current.Include(include)
                                         .AsSplitQuery()
                                         .AsNoTracking()
        );
    }
}