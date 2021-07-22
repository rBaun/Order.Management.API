using System.Collections.Generic;

namespace OrderManagement.Domain.Wrappers.Common
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }

        public Response() {}

        public Response(T data)
        {
            Data = data;
            Succeeded = true;
            Errors = new List<string>();
            Message = string.Empty;
        }
    }
}
