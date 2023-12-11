using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopyApp.Application.Common.Errors
{
    public class InvalidCredentialsError : IError
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;
        public string Message { get; set; } = "Invalid credentials";

    }
}
