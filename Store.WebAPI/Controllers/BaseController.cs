﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Store.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class BaseController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator? Mediator =>
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}