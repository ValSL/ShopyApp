using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyApp.Application.Common.Errors
{
    public interface IError
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
