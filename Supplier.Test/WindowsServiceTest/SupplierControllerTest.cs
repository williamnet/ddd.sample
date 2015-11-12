using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Supplier.Application.Models;
using Easy.Public.HttpRequestService;
namespace Supplier.Test.WindowsServiceTest
{
    public class SupplierControllerTest : BaseTest
    {
        private static readonly string baseUrl = ConfigurationManager.AppSettings["ServiceAddress"];
        private static readonly string addUrl = baseUrl + "api/Supplier/Add";
        private static readonly string findByIdUrl = baseUrl + "api/Supplier/FindById";
        private static readonly string openUrl = baseUrl + "api/Supplier/Open";
        private static readonly string closeUrl = baseUrl + "api/Supplier/Close";
        private static readonly string selectUrl = baseUrl + "api/Supplier/Select";

        [Test]
        public void AddSuccessTest()
        {
            var model = Create();

            var result = HttpRequestClient.Request(addUrl, "POST", "application/json").Send(model).GetBodyContent<ResultWithData<int>>();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ResultStatus == ResultStatus.Ok);
            Assert.IsTrue(result.DataBody > 0);
        }
        [Test]
        public void FindById()
        {
            var model = Create();
            var result = HttpRequestClient.Request(addUrl, "POST", "application/json").Send(model).GetBodyContent<ResultWithData<int>>();

            var findResult = HttpRequestClient.Request(findByIdUrl + "?supplierId=" + result.DataBody, "GET").Send().GetBodyContent<ResultWithData<DetailSupplierModel>>();

            Assert.IsTrue(findResult.ResultStatus == ResultStatus.Ok);
            Assert.AreEqual(model.Name, findResult.DataBody.Name);
            Assert.AreEqual(result.DataBody, findResult.DataBody.Id);
            Assert.AreEqual(model.BusinessTimeStart.Hour, findResult.DataBody.BusinessTime.Start.Hour);
            Assert.AreEqual(model.BusinessTimeEnd.Hour, findResult.DataBody.BusinessTime.End.Hour);
            Assert.AreEqual(model.DeliveryTime.Length, findResult.DataBody.DeliveryTime.Length);
        }
        [Test]
        public void OpenAndCloseTest()
        {
            var model = Create();
            var result = HttpRequestClient.Request(addUrl, "POST", "application/json").Send(model).GetBodyContent<ResultWithData<int>>();

            var findResult = HttpRequestClient.Request(findByIdUrl + "?supplierId=" + result.DataBody, "GET").Send().GetBodyContent<ResultWithData<DetailSupplierModel>>();

            Assert.AreEqual((int)Model.BusinessStatus.Close, findResult.DataBody.BusinessStatus);

            var openResult = HttpRequestClient.Request(openUrl + "?supplierId=" + result.DataBody, "POST").Send(new StringBuilder(result.DataBody.ToString())).GetBodyContent<Result>();

            Assert.AreEqual(ResultStatus.Ok, openResult.ResultStatus);

            findResult = HttpRequestClient.Request(findByIdUrl + "?supplierId=" + result.DataBody, "GET").Send().GetBodyContent<ResultWithData<DetailSupplierModel>>();
            Assert.AreEqual((int)Model.BusinessStatus.Open, findResult.DataBody.BusinessStatus);

            var closeResult = HttpRequestClient.Request(closeUrl + "?supplierId=" + result.DataBody, "POST").Send(new StringBuilder(result.DataBody.ToString()));

            findResult = HttpRequestClient.Request(findByIdUrl + "?supplierId=" + result.DataBody, "GET").Send().GetBodyContent<ResultWithData<DetailSupplierModel>>();
            Assert.AreEqual((int)Model.BusinessStatus.Close, findResult.DataBody.BusinessStatus);

        }
        [Test]
        public void SelectTest()
        {
            var model = Create();
            HttpRequestClient.Request(addUrl, "POST", "application/json").Send(model).GetBodyContent<ResultWithData<int>>();

            var model1 = Create();
            HttpRequestClient.Request(addUrl, "POST", "application/json").Send(model1).GetBodyContent<ResultWithData<int>>();

            var pcResult = HttpRequestClient.Request(selectUrl + "?pageSize=1&pageIndex=1", "GET").Send().GetBodyContent<ResultWithData<PageList<DetailSupplierModel>>>();

            Assert.AreEqual(pcResult.ResultStatus, ResultStatus.Ok);
            Assert.AreEqual(2, pcResult.DataBody.TotalRows);
            Assert.AreEqual(1, pcResult.DataBody.Collections.Count());

            var appResult = HttpRequestClient.Request(selectUrl + "?system=app&pageSize=1&pageIndex=1", "GET").Send().GetBodyContent<ResultWithData<PageList<APPSupplierData>>>();

            Assert.AreEqual(appResult.ResultStatus, ResultStatus.Ok);
            Assert.AreEqual(2, appResult.DataBody.TotalRows);
            Assert.AreEqual(1, appResult.DataBody.Collections.Count());
        }

        public AddSupplierModel Create()
        {
            var model = new AddSupplierModel()
            {
                Name = "好美味餐厅",
                Address = "北京朝阳区",
                Tel = "010-98989",
                CoordinatesLatitude = "13.2565665889",
                CoordinatesLongitude = "15.564654646",
                BusinessTimeStart = new TimeModel() { Hour = 0, Minute = 0 },
                BusinessTimeEnd = new TimeModel() { Hour = 23, Minute = 59 },
                DeliveryTime = new DeliveryTime[1] { 
                    new DeliveryTime() { 
                        Start = new TimeModel() { Hour = 11, Minute = 0 }, 
                        End = new TimeModel() { Hour = 13, Minute = 0 } } 
                },
            };
            return model;
        }

        [TearDown]
        public void Clear()
        {
            Model.RepositoryRegistry.Supplier.RemoveAll();
        }
    }


    class APPSupplierData
    {
        public int Id = 0;
        public string Name = string.Empty;
        public string Tel = string.Empty;
        public string Address = string.Empty;
        public bool DeliveryStatus = false;
        public int BusinessStatus = 0;
    }
}
