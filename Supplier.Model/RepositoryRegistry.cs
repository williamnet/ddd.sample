using Easy.Domain.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Model
{
    /// <summary>
    /// 仓储注册中心
    /// </summary>
    public static class RepositoryRegistry
    {
       readonly static RepositoryFactory factory;

        static RepositoryRegistry()
        {
            RepositoryFactoryBuilder builder = new RepositoryFactoryBuilder();

            factory = builder.Build(new System.IO.FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "repositories.config")));
        }

        public static ISupplierRepository Supplier
        {
            get
            {
                return factory.Get<ISupplierRepository>();
            }
        }
    }
}
