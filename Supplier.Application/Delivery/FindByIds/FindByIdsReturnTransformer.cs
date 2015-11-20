using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using Supplier.Application.Models;

namespace Supplier.Application.Delivery.FindByIds
{
    public class FindByIdsReturnTransformer : IReturnTransformer
    {
        public bool IsMapped(ReturnContext context)
        {
            return true;
        }

        public dynamic GetValue(ReturnContext context, object data)
        {
            IEnumerable<Model.Delivery> deliverys = data as IEnumerable<Model.Delivery>;
            return new ResultWithData<IEnumerable<DeliveryModel>>(ResultStatus.Ok, deliverys.Select(m => m.ToDeliveryModel()));
        }
    }
}
