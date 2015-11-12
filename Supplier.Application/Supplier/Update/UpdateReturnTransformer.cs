using Easy.Domain.Application;
using Supplier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Application.Supplier.Update
{
    public class UpdateReturnTransformer : IReturnTransformer
    {

        public dynamic GetValue(ReturnContext context, object data)
        {
            Model.Supplier supplier = data as Model.Supplier;

            if (supplier == null)
            {
                return new Result(ResultStatus.Error, "餐厅不存在");
            }
            if (supplier.GetBrokenRules().Count > 0)
            {
                return new Result(ResultStatus.Error, supplier.GetBrokenRules()[0].Description);
            }
            return new Result(ResultStatus.Ok);
        }

        public bool IsMapped(ReturnContext context)
        {
            return true;
        }
    }
}
