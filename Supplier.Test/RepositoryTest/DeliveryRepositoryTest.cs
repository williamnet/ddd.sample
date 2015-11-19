using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Supplier.Model;

namespace Supplier.Test.RepositoryTest
{
    public class DeliveryRepositoryTest
    {
        [Test]
        public void FindByIdsTest()
        {
            var ids = new int[2] { 1, 2 };

            var result = RepositoryRegistry.Delivery.FindByIds(ids);
            Assert.AreEqual(2, result.Count());
        }
    }
}
