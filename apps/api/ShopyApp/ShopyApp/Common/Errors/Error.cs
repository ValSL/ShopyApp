namespace ShopyApp.Common.Errors
{
    public class Error
    {
        public Error(string name, int statusCode, string message)
        {
            Name = name;
            StatusCode = statusCode;
            Message = message;
        }
        public string Name { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
