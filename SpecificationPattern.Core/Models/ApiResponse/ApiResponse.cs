using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Responses.Developer;

namespace Core.Models.ApiResponse
{
    public class ApiResponse<T> : IApiResponse<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T? Data { get; set; }

        public ApiResponse(string message, int statusCode, T? data)
        {
            Message = message;
            StatusCode = statusCode;
            Data = data;
        }
    }


    public class ApiResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        

        public ApiResponse(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
            
        }
    }
}
