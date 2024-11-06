using MediatR;

namespace Store.Application.Products.Commands.DeleteProductCommand;

public class DeleteProductCommand:IRequest
{
    public required int Id { get; set; }
}
