using Easy.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Model
{
    /// <summary>
    /// 餐厅实体
    /// </summary>
    public class Supplier : EntityBase<int>
    {
        public Supplier()
        {
            this.DeliveryTime = new DeliveryTime[0];
            this.BusinessTime = new BusinessTime(null, null);
            this.Coordinates = new Coordinates("", "");
            this.CreateDate = DateTime.Now;
            this.BusinessStatus = Model.BusinessStatus.Close;
        }
        /// <summary>
        /// 餐厅名称
        /// </summary>
        public String Name
        {
            get;
            set;
        }
        /// <summary>
        /// 餐厅地址
        /// </summary>
        public String Address
        {
            get;
            set;
        }
        /// <summary>
        /// 餐厅电话
        /// </summary>
        public String Tel
        {
            get;
            set;
        }
        /// <summary>
        /// 餐厅地理位置坐标
        /// </summary>
        public Coordinates Coordinates
        {
            get;
            set;
        }
        /// <summary>
        /// 餐厅营业时间
        /// </summary>
        public BusinessTime BusinessTime
        {
            get;
            set;
        }
        /// <summary>
        /// 餐厅可以送餐时间
        /// </summary>
        public DeliveryTime[] DeliveryTime
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate
        {
            get;
            private set;
        }
        /// <summary>
        /// 营业状态,请使用CurrentBusinessStatus方法获得餐厅营业状态
        /// </summary>
        public BusinessStatus BusinessStatus
        {
            get;
            protected set;
        }
        /// <summary>
        /// 获得餐厅当前营业状态
        /// </summary>
        /// <returns></returns>
        public BusinessStatus CurrentBusinessStatus
        {
            get
            {
                return new BusinessStatusService().GetStatus(this.BusinessStatus, this.BusinessTime);
            }
        }
        /// <summary>
        /// 获得当前餐厅是否可以送餐
        /// </summary>
        /// <returns>true表示可以送外，false表示不可以送餐</returns>
        public Boolean CurrentDeliveryStatus
        {
            get
            {
                return new DeliveryStatusService().GetDeliveryStatus(this.CurrentBusinessStatus, this.DeliveryTime);
            }
        }
        /// <summary>
        /// 开启营业，此状态优先级低于按时间的营业状态
        /// </summary>
        public void Open()
        {
            this.BusinessStatus = Model.BusinessStatus.Open;
        }
        /// <summary>
        /// 停止营业，此状态优先级高于按时间的营业状态
        /// </summary>
        public void Close()
        {
            this.BusinessStatus = Model.BusinessStatus.Close;
        }

        protected override BrokenRuleMessage GetBrokenRuleMessages()
        {
            return new SupplierBrokenRuleMessage();
        }
        public override bool Validate()
        {
            return new SupplierValidation().IsSatisfy(this);
        }
    }
}
