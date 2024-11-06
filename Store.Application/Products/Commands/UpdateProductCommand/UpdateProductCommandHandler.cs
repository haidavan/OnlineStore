using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Application.Exeptions;
using Store.Application.Interfaces;
using Store.Domain;

namespace Store.Application.Products.Commands.UpdateProductCommand;

public class UpdateProductCommandHandler(IDbContext dbContext):IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request,CancellationToken cancellationToken)
    {
        var targetProduct = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (targetProduct is null)
            throw new ExceptionNotFound(nameof(Product), request.Id);
        targetProduct.Name = request.Name;
        targetProduct.Description = request.Description;
        targetProduct.Article=request.Article;
        targetProduct.UrlImage = request.UrlImage;
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
