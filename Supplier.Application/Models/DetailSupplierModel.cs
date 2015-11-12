using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Application.Models
{
    /// <summary>
    /// 餐厅详情信息
    /// </summary>
    public class DetailSupplierModel
    {
        /// <summary>
        /// 餐厅ID
        /// </summary>
        public int Id;
        /// <summary>
        /// 餐厅名称
        /// </summary>
        public string Name;
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel;
        /// <summary>
        /// 餐厅地址
        /// </summary>
        public string Address;
        /// <summary>
        /// 餐厅营业状态
        /// <see cref="Supplier.Model.BusinessStatus"/>
        /// </summary>
        public int BusinessStatus;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate;
        /// <summary>
        /// 可送餐时间
        /// </summary>
        public DeliveryTime[] DeliveryTime;
        /// <summary>
        /// 营业时间
        /// </summary>
        public BusinessTime BusinessTime;
        /// <summary>
        /// 是否可送餐 true可以，false不可以
        /// </summary>
        public Boolean DeliveryStatus;
        /// <summary>
        /// 地理位置从标
        /// </summary>
        public Coordinates Coordinates; 

    }
}
