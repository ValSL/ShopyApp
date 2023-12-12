using System.Net;

namespace ShopyApp.Common.Errors
{
    public interface IError
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
