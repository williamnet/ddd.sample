using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Supplier.Model;
namespace Supplier.Test.ModelTest
{
    /// <summary>
    /// 是否可以送餐业务逻辑测试
    /// </summary>
    public class DeliveryStatusServiceTest
    {
        [Test]
        [Description("停止营业不可送餐测试")]
        public void CloseStatusDeliveryStatusTest()
        {
            var deliveryTime = new DeliveryTime[2] 
            { 
                new DeliveryTime(new Time(12,0),new Time(13,0)),
                new DeliveryTime(new Time(18,0),new Time(19,0))
            };

            var service = new DeliveryStatusService();

            var result = service.GetDeliveryStatus(BusinessStatus.Close, deliveryTime);

            Assert.IsFalse(result);
        }
        [Test]
        [Description("在营业中，但不在送餐时间测试")]
        public void OpenStatusOutOfDeliveryTimeTest()
        {
            var deliveryTime = new DeliveryTime[1] 
            { 
                new DeliveryTime(new Time(DateTime.Now.AddHours(-3).Hour,0),new Time(DateTime.Now.AddHours(-2).Hour,0))
            };

            var service = new DeliveryStatusService();

            var result = service.GetDeliveryStatus(BusinessStatus.Open, deliveryTime);

            Assert.IsFalse(result);
        }
        [Test]
        [Description("在送餐时间测试")]
        public void OpenStatusInDeliveryTimeTest()
        {
            var deliveryTime = new DeliveryTime[1] 
            { 
                new DeliveryTime(new Time(DateTime.Now.AddHours(-3).Hour,0),new Time(DateTime.Now.AddHours(3).Hour,0))
            };

            var service = new DeliveryStatusService();

            var result = service.GetDeliveryStatus(BusinessStatus.Open, deliveryTime);

            Assert.IsTrue(result);
        }
    }
}
