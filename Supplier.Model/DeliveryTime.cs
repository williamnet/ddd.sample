using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Model
{
    /// <summary>
    /// 送餐时间
    /// </summary>
    public class DeliveryTime
    {
        public DeliveryTime(Time start,Time end)
        {
            this.Start = start;
            this.End = end;
        }
        public Time Start
        {
            get;
            private set;
        }
        public Time End
        {
            get;
            private set;
        }
    }
}
