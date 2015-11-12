using Easy.Domain.Application;
using Supplier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Application.Supplier.FindById
{
    public class FindByIdReturnTransformer:IReturnTransformer
    {
        public dynamic GetValue(ReturnContext context, object data)
        {
            Model.Supplier supplier = data as Model.Supplier;

            if (supplier == null)
            {
                return new ResultWithData<DetailSupplierModel>(ResultStatus.Error, null, "餐厅不存在");
            }
            return new ResultWithData<DetailSupplierModel>(ResultStatus.Ok, supplier.ToDetailSupplierModel());
        }

        public bool IsMapped(ReturnContext context)
        {
            return true;
        }
    }
}
