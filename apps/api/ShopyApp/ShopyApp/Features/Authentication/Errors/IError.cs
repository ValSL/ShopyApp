using System.Net;

namespace ShopyApp.Application.Common.Errors
{
    public interface IError
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
