using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.WindowsService
{
    partial class SupplierWindowsService : ServiceBase
    {
        IDisposable web;

        public SupplierWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string baseUrl = ConfigurationManager.AppSettings["ServiceAddress"];
            try
            {
                web = WebApp.Start<Startup>(new StartOptions(baseUrl));
            }
            catch (Exception e)
            {
                Easy.Public.MyLog.LogManager.Error(e.Message, e.StackTrace);
                if (web != null)
                {
                    web.Dispose();
                }
            }
        }
        protected override void OnStop()
        {
            if (web != null)
            {
                web.Dispose();
            }
        }
    }
}
