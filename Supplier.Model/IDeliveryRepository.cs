using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;

namespace Supplier.Model
{
    public interface IDeliveryRepository : IRepository<Delivery, int>
    {
        IEnumerable<Delivery> FindByIds(int[] deliveryIds);
    }
}
