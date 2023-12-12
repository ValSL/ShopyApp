using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyApp.Contracts.Authentication
{
    public record AuthResposne(
        string FirstName,
        string LastName,
        string Email,
        string Token);
}
