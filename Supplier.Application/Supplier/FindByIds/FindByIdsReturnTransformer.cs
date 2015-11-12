using Easy.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supplier.Application.Models;
namespace Supplier.Application.Supplier.FindByIds
{
    public class FindByIdsReturnTransformer : IReturnTransformer
    {
        public dynamic GetValue(ReturnContext context, object data)
        {
            IEnumerable<Model.Supplier> suppliers = data as IEnumerable<Model.Supplier>;
            return new ResultWithData<IEnumerable<DetailSupplierModel>>(ResultStatus.Ok, suppliers.Select(m => m.ToDetailSupplierModel()));
        }

        public bool IsMapped(ReturnContext context)
        {
            return true;
        }
    }
}
