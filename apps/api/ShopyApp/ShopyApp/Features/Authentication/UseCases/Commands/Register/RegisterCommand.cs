using MediatR;
using OneOf;
using ShopyApp.Application.Common;
using ShopyApp.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyApp.Features.Authentication.UseCases.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<OneOf<AuthenticationResult, IError>>;
}
