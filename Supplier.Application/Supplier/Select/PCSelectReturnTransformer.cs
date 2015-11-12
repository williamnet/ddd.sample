using Easy.Domain.Application;
using Supplier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Application.Supplier.Select
{
    public class PCSelectReturnTransformer : IReturnTransformer
    {
        public dynamic GetValue(ReturnContext context, object data)
        {
            PageList<Model.Supplier> page = data as PageList<Model.Supplier>;

            return new ResultWithData<PageList<DetailSupplierModel>>(ResultStatus.Ok, new PageList<DetailSupplierModel>()
            {
                TotalRows = page.TotalRows,
                Collections = page.Collections.Select(m => m.ToDetailSupplierModel()).ToList()
            });
        }

        public bool IsMapped(ReturnContext context)
        {
            return context.SystemId == "pc" || string.IsNullOrEmpty(context.SystemId);
        }
    }
}
