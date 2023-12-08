using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopyApp.Application.Common.Errors
{
    public class DuplicateEmailError : IError
    {
        public int StatusCode { get; set; } = (int)HttpStatusCode.Conflict;
        public string Message { get; set; } = "User with given email already exists.";
    }
}
