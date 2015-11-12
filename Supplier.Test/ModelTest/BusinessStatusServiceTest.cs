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
    /// 营业状态单元测试
    /// </summary>
    public class BusinessStatusServiceTest
    {
        [Test]
        [Description("停止营业状态测试")]
        public void ClosedStatusTest()
        {
            var service = new BusinessStatusService();

            BusinessStatus status = service.GetStatus(BusinessStatus.Close, new BusinessTime(new Time(8, 0), new Time(20, 0)));

            Assert.AreEqual(BusinessStatus.Close, status);
        }
        [Test]
        [Description("在营业时间之外营业状态测试")]
        public void ClosedOutOfBusinessTimeTest()
        {
            var service = new BusinessStatusService();
            BusinessStatus status = service.GetStatus(BusinessStatus.Open, new BusinessTime(new Time(DateTime.Now.AddHours(1).Hour, 0), new Time(DateTime.Now.AddHours(2).Hour, 0)));

            Assert.AreEqual(BusinessStatus.Close, status);

        }
        [Test]
        [Description("在营业状态测试")]
        public void OpenStatusTest()
        {
            var service = new BusinessStatusService();
            BusinessStatus status = service.GetStatus(BusinessStatus.Open, new BusinessTime(new Time(DateTime.Now.AddHours(-1).Hour, 0), new Time(DateTime.Now.AddHours(1).Hour, 0)));

            Assert.AreEqual(BusinessStatus.Open, status);
        }
    }
}
