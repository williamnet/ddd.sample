using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;

namespace Supplier.Application
{
    public class DeliveryApplication : BaseApplication
    {
        public IReturn FindByIds(int[] deliveryIds)
        {
            IEnumerable<Model.Delivery> delivery = Model.RepositoryRegistry.Delivery.FindByIds(deliveryIds);

            return this.Write("FindByIds", delivery);
        }
    }
}
