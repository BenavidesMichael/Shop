using System.Linq.Expressions;
using MediatR;
using Shop.Application.Persistence;
using Shop.Domain.Entities;

namespace Shop.Application.Features.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsRequest, IReadOnlyList<GetProductsResponse>>
{
    private readonly IUnitOfWork _unitofwork;

    public GetProductsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitofwork = unitOfWork;
    }

    public async Task<IReadOnlyList<GetProductsResponse>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        var includes = new List<Expression<Func<Product, object>>>();
        includes.Add(p => p.Images);
        includes.Add(p => p.Reviews);

        var products =  await _unitofwork.Repository<Product>().GetAsync(null, p => p.OrderBy(p => p.Name), includes);

        return products.Select(p => new GetProductsResponse
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Images = p?.Images.Select(i => i.Url).ToList(),
            Reviews = p?.Reviews.Select(r => r.Comment).ToList()
        }).ToList();

    }
}