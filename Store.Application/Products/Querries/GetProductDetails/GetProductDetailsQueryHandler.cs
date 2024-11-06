using AutoMapper;
using MediatR;
using Store.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Store.Domain;
using Store.Application.Exeptions;

namespace Store.Application.Products.Querries.GetProductDetails;

public class GetProductDetailsQueryHandler(IMapper mapper,IDbContext dbContext):IRequestHandler<GetProductDetailsQuery,ProductViewModel>
{
    public async Task<ProductViewModel> Handle(GetProductDetailsQuery query,CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.SingleOrDefaultAsync(x => x.Id == query.Id);
        if (product == null)
            throw new ExceptionNotFound(nameof(Product),query.Id);
        return mapper.Map<ProductViewModel>(product);
    }
}
