using System.Collections.Generic;
using System.Linq;

namespace MediatRDemo.Api.DTO
{
    public class Response
    {
        public Response(IEnumerable<string> errorList = null)
        {
            ErrorList = errorList ?? new string[0];
            Error = ErrorList.Any();
        }
        public IEnumerable<string> ErrorList { get; set; }
        public bool Error { get; set; }
    }

    public class Response<T> : Response
    {
        public Response(T data, IEnumerable<string> errorList = null) : base(errorList)
        {
            Data = data;
        }

        public T Data { get; set; }
    }

    public static class ResponseFactory
    {
        public static Response<T> Fail<T>(params string[] errorList) => new Response<T>(default, errorList);
        public static Response Fail(params string[] errorList) => new Response(errorList);
        public static Response<T> Ok<T>(T data, params string[] errorList) => new Response<T>(data, errorList);
        public static Response Ok(params string[] errorList) => new Response(errorList);
    }
}
