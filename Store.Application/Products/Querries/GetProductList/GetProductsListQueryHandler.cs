using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces;

namespace Store.Application.Products.Querries.GetProductList;

public class GetProductsListQueryHandler(IMapper mapper,IDbContext dbContext):IRequestHandler<GetProductListQuery,ProductsListViewModel>
{
    public async Task<ProductsListViewModel> Handle(GetProductListQuery query,CancellationToken cancellationToken)
    {
        var products = await dbContext.Products
           .ProjectTo<ProductLookUpDTO>(mapper.ConfigurationProvider)
           .Skip(query.SkipProductsCount)
           .Take(query.TakeProductsCount)
           .ToListAsync(cancellationToken);

        return new ProductsListViewModel
        {
            ProductsLookUp = products
        };
    }
}
