using MediatR;
using OneOf;
using ShopyApp.Application.Common;
using ShopyApp.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyApp.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<OneOf<AuthenticationResult, List<Error>>>;
}
