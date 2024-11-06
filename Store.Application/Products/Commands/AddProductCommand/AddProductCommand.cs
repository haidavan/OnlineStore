﻿using MediatR;

namespace Store.Application.Products.Commands.AddProductCommand;

public class AddProductCommand:IRequest<int>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string UrlImage { get; set; }
    public required string Article { get; set; }
}