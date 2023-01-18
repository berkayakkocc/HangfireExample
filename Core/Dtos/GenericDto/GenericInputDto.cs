using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.GenericDto
{
     public class GenericInputDto<T>
    {
        public T? Data { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        //public string? OrderedColumn { get; set; }
        //public string? OrderType { get; set; }


        public static GenericInputDto<T> ResponseData(T? data, int skip = 0, int take = int.MaxValue, /*string orderedColumn = "Id", string orderType = EntityOrderType.OrderAsc*/)
        {
            return new GenericInputDto<T> { Data = data, Skip = skip, Take = take/*, OrderedColumn = orderedColumn, OrderType = orderType*/ };
        }



    }
}
