using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Supplier.Model;
namespace Supplier.Test.RepositoryTest
{
    /// <summary>
    /// 对于单元测试至少需要测试两情况，1是测试全量正确的数据插入和更新操作，2测试默认数据的插入和更新操作
    /// 也就是说 只new一个实体，不做任赋值的测试
    /// </summary>
    public class SupplierRepositoryTest
    {
        [Test]
        public void AddTest()
        {
            Model.Supplier supplier = Create();
            RepositoryRegistry.Supplier.Add(supplier);

            Assert.IsTrue(supplier.Id > 0);

            var result = RepositoryRegistry.Supplier.FindBy(supplier.Id);

            SupplierAssert(supplier, result);
        }
        [Test]
        public void Add2Test()
        {
            var supplier = new Model.Supplier();
            RepositoryRegistry.Supplier.Add(supplier);

            var result = RepositoryRegistry.Supplier.FindBy(supplier.Id);

            Assert.AreEqual(supplier.Id, result.Id);
        }
        [Test]
        public void UpdateTest()
        {
            Model.Supplier supplier = Create();
            RepositoryRegistry.Supplier.Add(supplier);

            supplier.Name = "新名字";
            supplier.Tel = "123";
            supplier.BusinessTime = new BusinessTime(new Time(0, 0), new Time(24, 0));

            RepositoryRegistry.Supplier.Update(supplier);

            var actual = RepositoryRegistry.Supplier.FindBy(supplier.Id);

            SupplierAssert(supplier, actual);
        }

        [Test]
        public void RemoveTest()
        {
            Model.Supplier supplier = Create();
            RepositoryRegistry.Supplier.Add(supplier);

            RepositoryRegistry.Supplier.Remove(supplier);

            var actual = RepositoryRegistry.Supplier.FindBy(supplier.Id);

            Assert.IsNull(actual);
        }
        [Test]
        public void FindByIdsTest()
        {
            Model.Supplier supplier = Create();
            RepositoryRegistry.Supplier.Add(supplier);
            Model.Supplier supplier1 = Create();
            RepositoryRegistry.Supplier.Add(supplier1);

            var ids = new int[2] { supplier.Id, supplier1.Id };

            var result =RepositoryRegistry.Supplier.FindByIds(ids);
            Assert.AreEqual(2, result.Count());
        }
        [Test]
        public void SelectTest()
        {
            Model.Supplier supplier = Create();
            RepositoryRegistry.Supplier.Add(supplier);
            Model.Supplier supplier1 = Create();
            RepositoryRegistry.Supplier.Add(supplier1);

            int totalRows = 0;
            var result = RepositoryRegistry.Supplier.Select(1, 1, out totalRows);

            Assert.AreEqual(2, totalRows);
            Assert.AreEqual(1, result.Count());
        }

        void SupplierAssert(Model.Supplier expected, Model.Supplier actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Tel, actual.Tel);
            Assert.AreEqual(expected.Address, actual.Address);
            Assert.AreEqual(expected.BusinessStatus, actual.BusinessStatus);
            Assert.AreEqual(expected.BusinessTime.Start, actual.BusinessTime.Start);
            Assert.AreEqual(expected.BusinessTime.End, actual.BusinessTime.End);
            Assert.AreEqual(expected.Coordinates, actual.Coordinates);
            Assert.AreEqual(expected.CreateDate.Hour, actual.CreateDate.Hour);
            Assert.AreEqual(expected.DeliveryTime.Length, expected.DeliveryTime.Length);
        }
        [TearDown]
        public void Clear()
        {
            RepositoryRegistry.Supplier.RemoveAll();
        }

        public static Model.Supplier Create()
        {
            var coordinates = new Coordinates("133.15888", "4565566.8879879");

            var deliverytime = new DeliveryTime[2] { 
                new DeliveryTime(new Time(12,0),new Time(14,0)),
                new DeliveryTime(new Time(17,0),new Time(19,0))
            };

            var businessTime = new BusinessTime(new Time(10, 0), new Time(22, 0));

            return Create(businessTime, coordinates, deliverytime);
        }

        public static Model.Supplier Create(BusinessTime businessTime = null, Coordinates coordinates = null, DeliveryTime[] deliverytime = null)
        {
            var supplier = new Model.Supplier()
            {
                Name = "好美味餐厅",
                Address = "北京朝阳区三间房",
                Tel = "18500191543",
                BusinessTime = businessTime,
                Coordinates = coordinates,
                DeliveryTime = deliverytime,
            };

            return supplier;
        }
    }
}
