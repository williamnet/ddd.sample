using Easy.Domain.Application;
using Supplier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Application.Supplier.Select
{
    public class APPSelectReturnTransformer : IReturnTransformer
    {
        public dynamic GetValue(ReturnContext context, object data)
        {
            PageList<Model.Supplier> page = data as PageList<Model.Supplier>;

            return new ResultWithData<PageList<dynamic>>(ResultStatus.Ok, new PageList<dynamic>()
            {
                TotalRows = page.TotalRows,
                Collections = page.Collections.Select(m => new
                {
                    Id = m.Id,
                    Name = m.Name,
                    Tel = m.Tel,
                    Address = m.Address,
                    DeliveryStatus = m.CurrentDeliveryStatus(),
                    BusinessStatus = m.CurrentBusinessStatus()
                }).ToList<dynamic>()
            });
        }

        public bool IsMapped(ReturnContext context)
        {
            return context.SystemId == "app";
        }
    }
}
