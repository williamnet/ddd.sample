using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Application.Models
{
    /// <summary>
    /// 为前端组职数据，此数据结构一般尽量扁平
    /// </summary>
    public class AddSupplierModel
    {
        /// <summary>
        /// 餐厅名称
        /// </summary>
        public string Name;
        /// <summary>
        /// 地址
        /// </summary>
        public string Address;
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel;
        /// <summary>
        /// 地理坐标，经度
        /// </summary>
        public string CoordinatesLongitude;
        /// <summary>
        /// 地理坐标，纬度
        /// </summary>
        public string CoordinatesLatitude;
        /// <summary>
        /// 开始营业时间
        /// </summary>
        public TimeModel BusinessTimeStart;
        /// <summary>
        /// 结事营业时间
        /// </summary>
        public TimeModel BusinessTimeEnd;
        /// <summary>
        /// 可送餐时间
        /// </summary>
        public DeliveryTime[] DeliveryTime; 
    }
}
