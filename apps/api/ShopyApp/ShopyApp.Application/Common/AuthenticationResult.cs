using ShopyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyApp.Application.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
