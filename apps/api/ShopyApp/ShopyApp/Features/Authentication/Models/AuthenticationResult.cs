using ShopyApp.Features.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyApp.Application.Common
{
    public record AuthenticationResult(
         string FirstName,
         string LastName,
         string Email,
         string Token);
}
