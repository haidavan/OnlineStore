using MediatR;

namespace Store.Application.Products.Commands.UpdateProductCommand;

public class UpdateProductCommand:IRequest
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string UrlImage { get; set; }
    public required string Article { get; set; }
}
