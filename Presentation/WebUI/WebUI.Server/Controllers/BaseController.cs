﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Server.Controllers;

public abstract class BaseController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
