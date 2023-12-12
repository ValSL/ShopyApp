using System.Net;
using ShopyApp.Common.Errors;

namespace ShopyApp.Application.Common.Errors
{
    public class DuplicateEmailError : IError
    {
        public int StatusCode { get; set; } = StatusCodes.Status409Conflict;
        public string Message { get; set; } = "User with given email already exists.";
    }
}
