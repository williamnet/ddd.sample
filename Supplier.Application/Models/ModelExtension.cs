using Easy.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Supplier.Application.Models
{
    static class ModelExtension
    {
        public static Model.Supplier ToSupplier(this AddSupplierModel model)
        {
            return ToSupplier(model, new Model.Supplier());
        }

        public static Model.Supplier ToSupplier(this AddSupplierModel model, Model.Supplier supplier)
        {
            supplier.Name = model.Name;
            supplier.Tel = model.Tel;
            supplier.Address = model.Address;
            supplier.BusinessTime = new Model.BusinessTime(model.BusinessTimeStart.ToTime(), model.BusinessTimeEnd.ToTime());

            supplier.Coordinates = new Model.Coordinates(model.CoordinatesLongitude, model.CoordinatesLatitude);

            supplier.DeliveryTime = NullHelper.IfNull(model.DeliveryTime, new DeliveryTime[0]).Select(m => m.ToDeliveryTime()).ToArray();

            return supplier;
        }

        public static Model.Time ToTime(this TimeModel timeModel)
        {
            var time = new Model.Time(timeModel.Hour, timeModel.Minute);
            return time;
        }

        public static Model.DeliveryTime ToDeliveryTime(this DeliveryTime model)
        {
            var deliveryTime = new Model.DeliveryTime(model.Start.ToTime(), model.End.ToTime());
            return deliveryTime;
        }

        public static DetailSupplierModel ToDetailSupplierModel(this Model.Supplier model)
        {
            var supplier = new DetailSupplierModel()
            {
                Id = model.Id,
                Tel = model.Tel,
                Address = model.Address,
                Name = model.Name,
                BusinessStatus = (int)model.CurrentBusinessStatus,
                BusinessTime = model.BusinessTime.ToBusinessTime(),
                CreateDate = model.CreateDate,
                DeliveryStatus = model.CurrentDeliveryStatus,
                DeliveryTime = model.DeliveryTime.Select(m => new DeliveryTime() { Start = m.Start.ToTimeModel(), End = m.End.ToTimeModel() }).ToArray(),
                Coordinates = new Coordinates() { Longitude = model.Coordinates.Longitude, Latitude = model.Coordinates.Latitude }
            };

            return supplier;
        }

        public static BusinessTime ToBusinessTime(this Model.BusinessTime model)
        {
            var btime = new BusinessTime()
            {
                Start = model.Start.ToTimeModel(),
                End = model.End.ToTimeModel()
            };
            return btime;
        }

        public static TimeModel ToTimeModel(this Model.Time model)
        {
            var time = new TimeModel()
            {
                Hour = model.Hour,
                Minute= model.Minute
            };
            return time;
        }

        public static DeliveryModel ToDeliveryModel(this Model.Delivery model)
        {
            var delivery = new DeliveryModel()
            {
                Id = model.Id,
                Name = model.Name
            };
            return delivery;
        }
    }
}
