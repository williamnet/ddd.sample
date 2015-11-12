using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Model
{
    /// <summary>
    /// 餐厅是否可以送餐的业务逻辑
    /// </summary>
    public class DeliveryStatusService
    {
        /// <summary>
        /// 计算餐厅是否可以送餐
        /// </summary>
        /// <param name="status">餐厅营业状态</param>
        /// <param name="deliverTime">餐厅可以送餐时间</param>
        /// <returns>true表示可以送餐，false不可以送餐</returns>
        public Boolean GetDeliveryStatus(BusinessStatus status, DeliveryTime[] deliverTime)
        {
            if (status == BusinessStatus.Close)
            {
                return false;
            }
            var now = DateTime.Now;
            return deliverTime.Count(d => now > d.Start.GetDateTime() && now <= d.End.GetDateTime()) > 0;
        }
    }
}
