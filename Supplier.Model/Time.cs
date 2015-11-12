using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Model
{
    public class Time
    {
        public Time(int hour,int minute)
        {
            this.Hour = hour;
            this.Minute = minute;
        }

        public int Hour
        {
            get;
            private set;
        }
        public int Minute
        {
            get;
            private set;
        }
        /// <summary>
        /// 获得时间表示
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateTime()
        {
            var now = DateTime.Now;
            return new DateTime(now.Year, now.Month, now.Day, this.Hour, this.Minute, 0);
        }

        public override string ToString()
        {
            return this.Hour + ":" + this.Minute;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj as Time == null)
            {
                return false;
            }

            Time time = obj as Time;

            if (this.Hour == time.Hour && this.Minute == time.Minute)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.Hour ^ this.Minute;
        }
    }
}
