using MediatR;

namespace Shop.Application.Features.Products.Queries.GetProducts;

public class GetProductsRequest : IRequest<IReadOnlyList<GetProductsResponse>>
{
}