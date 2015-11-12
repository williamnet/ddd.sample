using Easy.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Application
{
    /// <summary>
    /// 应用服务注册中心
    /// </summary>
    public static class ApplicationRegistry
    {
        static ApplicationRegistry()
        {
            ApplicationFactory.Instance().Register(new SupplierApplication());
        }

        public static SupplierApplication Supplier
        {
            get
            {
                return ApplicationFactory.Instance().Get<SupplierApplication>();
            }
        }
    }
}
