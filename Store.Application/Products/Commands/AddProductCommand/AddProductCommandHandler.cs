using MediatR;
using Store.Application.Interfaces;
using Store.Domain;

namespace Store.Application.Products.Commands.AddProductCommand;

public class AddProductCommandHandler(IDbContext dbContext):IRequestHandler<AddProductCommand,int>
{
    public async Task<int> Handle(AddProductCommand request,CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Description = request.Description,
            Article=request.Article,
            Name=request.Name,
            UrlImage=request.UrlImage,
        };
        await dbContext.Products.AddAsync(product);
        await dbContext.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}
