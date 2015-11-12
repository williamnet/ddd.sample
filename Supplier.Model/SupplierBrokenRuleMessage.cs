using Easy.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Model
{
    class SupplierBrokenRuleMessage:BrokenRuleMessage
    {
        public const string NameIsEmpty = "餐厅名称不能为空";
        public const string NameLengthIsOut = "餐厅名称不超过20个字符";
        public const string AddressIsEmpty = "地址不能为空";
        public const string AddressLengthIsOut = "地址长度不能超过100个字符";

        public const string TelIsEmpty = "电话不能为空";
        public const string TelIsTooLong = "电话号码不能超过11位";
        public const string TelStringError = "电话号码只包含数字和-";

        public const string CoordinatesError = "地理坐标不能为空";
        public const string BusinessTimeError = "营业时间错误";

        public const string DeliveryTimeError = "送餐时间错误";

        protected override void PopulateMessage()
        {
            this.Messages.Add(NameIsEmpty, NameIsEmpty);
            this.Messages.Add(NameLengthIsOut, NameLengthIsOut);

            this.Messages.Add(AddressIsEmpty, AddressIsEmpty);
            this.Messages.Add(AddressLengthIsOut, AddressLengthIsOut);

            this.Messages.Add(TelIsEmpty, TelIsEmpty);
            this.Messages.Add(TelStringError, TelStringError);

            this.Messages.Add(CoordinatesError, CoordinatesError);
            this.Messages.Add(BusinessTimeError, BusinessTimeError);
        }
    }
}
