using Essensys.Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebInterface.Controllers
{
 
    public abstract class BaseController : Controller
    {
        private IMediator _mediator;
        private ICurrentUserService _userService;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
