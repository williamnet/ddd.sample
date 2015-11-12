using Supplier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Infrastructure.Repository
{
    static class TimeHelper
    {
        /// <summary>
        /// time格式转换 eg:10:00
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static Time StringToTime(string time)
        {
            if (string.IsNullOrWhiteSpace(time))
            {
                return null;
            }
            var timeArray = time.Split(':');

            return new Time(int.Parse(timeArray[0]), int.Parse(timeArray[1]));
        }
        /// <summary>
        /// 时间数组转换 eg 10:00-20:00|12:00-13:00
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public static DeliveryTime[] StringArrayToTimeArray(string times)
        {
            if (string.IsNullOrWhiteSpace(times))
            {
                return new DeliveryTime[0];
            }

            var deliveryTime = times.Split('|').Select(m => m.Split('-').Select(t =>
            {
                var item = t.Split(':');
                return new Time(int.Parse(item[0]), int.Parse(item[1]));
            }).ToArray()).Select(d => new DeliveryTime(d[0], d[1])).ToArray();

            return deliveryTime;
        }
    }
}
