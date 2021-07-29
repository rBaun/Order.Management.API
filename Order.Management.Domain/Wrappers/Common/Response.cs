using System.Collections.Generic;

namespace OrderManagement.Domain.Wrappers.Common
{
    public class Response<T>
    {
        public Response()
        {
            Errors = new List<string>();
        }

        public Response(T data)
        {
            Data = data;
            Succeeded = true;
            Errors = new List<string>();
            Message = string.Empty;
        }

        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }
    }
}