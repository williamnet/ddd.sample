using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Supplier.Model;

namespace Supplier.Test.ModelTest
{
    public class SupplierValidationTest
    {
        [Test]
        public void FaildValidationTest()
        {

            var supplier = new Model.Supplier();

            var result =  supplier.Validate();

            Assert.IsFalse(result);

            Assert.IsTrue(supplier.GetBrokenRules().Count > 0);
        }
        [Test]
        [Description("营业时间测试")]
        public void BusinessTimeTest()
        {
            var coordinates = new Coordinates("133.15888", "4565566.8879879");

            var deliverytime = new DeliveryTime[1] { 
                new DeliveryTime(new Time(12,0),new Time(14,0))
            };

            //测试时间格式不正确
            var businessTime = new BusinessTime(new Time(100, 0), new Time(2, 0));
            var supplier = Create(businessTime, coordinates, deliverytime);

            var result = supplier.Validate();
            Assert.IsFalse(result);
            Assert.IsTrue(supplier.GetBrokenRules().Count == 1);

            //测试开始营业时间，在于结束营业时间

            businessTime = new BusinessTime(new Time(22, 0), new Time(10, 0));
            supplier = Create(businessTime, coordinates, deliverytime);

            result = supplier.Validate();
            Assert.IsFalse(result);
            Assert.IsTrue(supplier.GetBrokenRules().Count == 1);

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
