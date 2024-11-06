using MediatR;

namespace Store.Application.Products.Querries.GetProductDetails;

public class GetProductDetailsQuery:IRequest<ProductViewModel>
{
    public int Id { get; set; }
}
