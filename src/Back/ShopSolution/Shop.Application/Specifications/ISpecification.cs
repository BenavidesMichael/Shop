using System.Linq.Expressions;
namespace Shop.Application.Specifications;

public interface ISpecification<T>
{
    Expression<Func<T, bool>>? Requirement { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    Expression<Func<T, object>>? OrderBy { get; }
    Expression<Func<T, object>>? OrderByDescending { get; }
    int Take { get; }
    int Skip { get; }
    bool IsPagingEnable { get; }
}