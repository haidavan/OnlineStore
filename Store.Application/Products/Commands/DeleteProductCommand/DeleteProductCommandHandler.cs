using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Application.Exeptions;
using Store.Application.Interfaces;
using Store.Domain;

namespace Store.Application.Products.Commands.DeleteProductCommand;

public class DeleteProductCommandHandler(IDbContext dbContext):IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand request,CancellationToken cancellationToken)
    {
        var targetProduct=await dbContext.Products.FirstOrDefaultAsync(x=>x.Id==request.Id);
        if (targetProduct is null)
            throw new ExceptionNotFound(nameof(Product),request.Id);
        dbContext.Products.Remove(targetProduct);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
