using System.Net;

namespace ShopyApp.Application.Common.Errors
{
    public class DuplicateEmailError : IError
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Conflict;
        public string Message { get; set; } = "User with given email already exists.";
    }
}
