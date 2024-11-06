using MediatR;

namespace Store.Application.Products.Querries.GetProductList;

public class GetProductListQuery:IRequest<ProductsListViewModel>
{
    public int SkipProductsCount { get; set; }
    public int TakeProductsCount { get; set; }
}
