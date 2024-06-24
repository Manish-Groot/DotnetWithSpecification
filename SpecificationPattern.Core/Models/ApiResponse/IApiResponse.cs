using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.ApiResponse
{
    public interface IApiResponse<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T? Data { get; set; }
    }
}
