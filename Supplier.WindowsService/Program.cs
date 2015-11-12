using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Supplier.WindowsService
{
    public static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        public static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                string baseUrl = ConfigurationManager.AppSettings["ServiceAddress"];
                using (WebApp.Start<Startup>(new StartOptions(baseUrl)))
                {
                    while (true)
                    {
                        Thread.Sleep(80000012);
                    }
                }
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                    { 
                        new SupplierWindowsService() 
                    };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
