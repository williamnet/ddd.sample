using Easy.Domain.Application;
using Supplier.Application;
using Supplier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Supplier.WindowsService
{
    /// <summary>
    /// 餐厅 resful API
    /// </summary>
    public class SupplierController : ApiController
    {
        /// <summary>
        /// 添加餐厅
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Add(AddSupplierModel model)
        {
            IReturn @return = ApplicationRegistry.Supplier.Add(model);
            return Json(@return.Result(new ReturnContext()));
        }
        /// <summary>
        /// 根据ID查
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult FindById(int supplierId = 0)
        {
            IReturn @return = ApplicationRegistry.Supplier.FindById(supplierId);
            return Json(@return.Result(new ReturnContext()));
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="system">pc或app</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Select(string system = "pc", int pageSize = 20, int pageIndex = 0)
        {
            IReturn @return = ApplicationRegistry.Supplier.Select(pageSize, pageIndex);
            return Json(@return.Result(new ReturnContext() { SystemId = system }));
        }
        /// <summary>
        /// 开启营业
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Open(int supplierId = 0)
        {
            IReturn @return = ApplicationRegistry.Supplier.Open(supplierId);
            return Json(@return.Result(new ReturnContext()));
        }
        /// <summary>
        /// 停业
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Close(int supplierId = 0)
        {
            IReturn @return = ApplicationRegistry.Supplier.Close(supplierId);
            return Json(@return.Result(new ReturnContext()));
        }
    }
}
