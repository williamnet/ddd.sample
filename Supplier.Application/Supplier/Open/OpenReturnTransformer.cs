using Easy.Domain.Application;
using Supplier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Application.Supplier.Open
{
    public class OpenReturnTransformer : IReturnTransformer
    {
        public dynamic GetValue(ReturnContext context, object data)
        {
            Model.Supplier supplier = data as Model.Supplier;
            if (supplier == null)
            {
                return new Result(ResultStatus.Error, "餐厅不存在");
            }
            return new Result(ResultStatus.Ok);
        }

        public bool IsMapped(ReturnContext context)
        {
            return true;
        }
    }
}
