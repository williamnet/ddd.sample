using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Model
{
    static class TimeCheckHelper
    {
        /// <summary>
        /// 小时检查
        /// </summary>
        /// <param name="hour"></param>
        /// <returns>tru表示检查通过，false检查不通过</returns>
        public static bool HourCheck(int hour)
        {
            if (hour >= 0 && hour < 24)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 分检查
        /// </summary>
        /// <param name="minute"></param>
        /// <returns>tru表示检查通过，false检查不通过</returns>
        public static bool MinuteCheck(int minute)
        {
            if (minute >= 0 && minute <= 59)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 时间检查
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static bool TimeCheck(Time time)
        {
            if (time == null)
            {
                return false;
            }

            if (!HourCheck(time.Hour) || !MinuteCheck(time.Minute))
            {
                return false;
            }
            return true;
        }
    }
}
