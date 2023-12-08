using Microsoft.AspNetCore.Builder;
using ShopyApp.Models;
using ShopyApp.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using ShopyApp.Application.Common.Errors;
using ShopyApp.Application.Common;
using MediatR;
using ShopyApp.Application.Authentication.Commands.Register;
using MapsterMapper;
using ShopyApp.Application.Authentication.Queries.Login;

namespace ShopyApp.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AuthController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var registerCommand = _mapper.Map<RegisterCommand>(request);
            var authResult = await _mediator.Send(registerCommand);

            return authResult.Match(
                result => Ok(_mapper.Map<AuthResposne>(result)),
                error => Problem(title: error.Message, statusCode: error.StatusCode));
        }

        

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var registerCommand = _mapper.Map<LoginQuery>(request);

            var authResult = await _mediator.Send(registerCommand);
            

            return authResult.Match(
                result => Ok(_mapper.Map<AuthResposne>(result)),
                error => Problem(title: error.Message, statusCode: error.StatusCode));
        }
    }
}
