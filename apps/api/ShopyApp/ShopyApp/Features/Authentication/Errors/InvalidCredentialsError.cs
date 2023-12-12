using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ShopyApp.Common.Errors;

namespace ShopyApp.Application.Common.Errors
{
    public class InvalidCredentialsError : IError
    {
        public int StatusCode { get; set; } = StatusCodes.Status400BadRequest;
        public string Message { get; set; } = "Invalid credentials";

    }
}
