using Easy.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Message = Supplier.Model.SupplierBrokenRuleMessage;
namespace Supplier.Model
{
    class SupplierValidation : EntityValidation<Supplier>
    {
        public const string chars = "0123456789-";

        public SupplierValidation()
        {
            this.IsNullOrWhiteSpace(m => m.Name, Message.NameIsEmpty);
            this.MaxStringLength(m => m.Name, 20, Message.NameLengthIsOut);


            this.IsNullOrWhiteSpace(m => m.Address, Message.AddressIsEmpty);
            this.MaxStringLength(m => m.Address, 100, Message.AddressLengthIsOut);

            this.IsNullOrWhiteSpace(m => m.Tel, Message.TelIsEmpty);
            this.MaxStringLength(m => m.Tel, 11, Message.TelIsTooLong);
            this.IncludeChars(m => m.Tel, chars.ToCharArray(), Message.TelStringError);

            this.AddRule(m => m.Coordinates, (s) =>
            {
                if (s.Coordinates == null)
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(s.Coordinates.Latitude) || string.IsNullOrWhiteSpace(s.Coordinates.Longitude))
                {
                    return false;
                }
                return true;

            }, Message.CoordinatesError);

            this.AddRule(m => m.BusinessTime, (s) =>
            {
                if (s.BusinessTime == null)
                {
                    return false;
                }
                if (!TimeCheckHelper.TimeCheck(s.BusinessTime.Start) || !TimeCheckHelper.TimeCheck(s.BusinessTime.End))
                {
                    return false;
                }

                if (s.BusinessTime.Start.GetDateTime() >=s.BusinessTime.End.GetDateTime())
                {
                    return false;
                }

                return true;
            }, Message.BusinessTimeError);

            this.AddRule(m => m.DeliveryTime, (s) =>
            {
                if (s.DeliveryTime == null || s.DeliveryTime.Length == 0)
                {
                    return false;
                }

                foreach (DeliveryTime time in s.DeliveryTime)
                {
                    if (!TimeCheckHelper.TimeCheck(time.Start) || !TimeCheckHelper.TimeCheck(time.End))
                    {
                        return false;
                    }

                    if (time.Start.GetDateTime() >= time.End.GetDateTime())
                    {
                        return false;
                    }
                }
                return true;

            }, Message.DeliveryTimeError);
        }
    }
}
