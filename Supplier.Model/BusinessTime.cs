using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Model
{
    public class BusinessTime
    {
        public BusinessTime(Time start,Time end)
        {
            this.Start = start;
            this.End = end;
        }
        /// <summary>
        /// 营业开始时间
        /// </summary>
        public Time Start
        {
            get;
            private set;
        }
        /// <summary>
        /// 营业结束时间
        /// </summary>
        public Time End
        {
            get;
            private set;
        }
    }
}
