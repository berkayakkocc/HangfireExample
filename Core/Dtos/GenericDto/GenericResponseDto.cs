using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.GenericDto
{
    public class GenericResponseDto<TEntity> 
    {

        public GenericResponseDto()
        {

        }

        public TEntity? Data { get; set; }

        public bool IsSuccessful { get; set; }

        public int StatusCode { get; set; }

        public string? Error { get; set; }
        public int? TotalCount { get; set; }

        public static GenericResponseDto<TEntity> ResponseData(TEntity? data, int statusCode, string? error, int? totalCount = 0)
        {
            return new GenericResponseDto<TEntity> { Data = data, StatusCode = statusCode, IsSuccessful = !String.IsNullOrEmpty(error) ? false : true, Error = error, TotalCount = totalCount };
        }

    }
}
