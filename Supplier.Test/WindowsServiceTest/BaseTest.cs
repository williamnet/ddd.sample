using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Supplier.Test.WindowsServiceTest
{
    public class BaseTest
    {
        static BaseTest()
        {
            //启动 web 服务

            new Thread(new System.Threading.ThreadStart(() =>
            {
                Supplier.WindowsService.Program.Main(new string[1] { "a" });
            })).Start();
        }
    }
}
