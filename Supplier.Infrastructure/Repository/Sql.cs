using Easy.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Infrastructure.Repository
{
    static class Sql
    {
        public static string BaseSelectSql()
        {
            return @"SELECT id AS ID, name AS Name, address AS Address, tel AS Tel, create_date AS CreateDate, business_status AS BusinessStatus,
                1 AS split,
                coordnate_longitude AS longitude, coordnate_latitude AS latitude, 
                1 AS split,
                businesstime_start, businesstime_end, 
                1 AS split,                
                delivery_time 
                FROM supplier";
        }

        public static Model.Supplier SelectConvert(Model.Supplier s,object c, object o1, object o2)
        {
            var coordinatesDic = c as IDictionary<string, object>;
            var coordinates = new Model.Coordinates(coordinatesDic["longitude"].ToString(), coordinatesDic["latitude"].ToString());

            s.Coordinates = coordinates;

            var bussinestimeDic = o1 as IDictionary<string, object>;

            var bussinestime = new Model.BusinessTime(TimeHelper.StringToTime(bussinestimeDic["businesstime_start"].ToString()), TimeHelper.StringToTime(bussinestimeDic["businesstime_end"].ToString()));

            s.BusinessTime = bussinestime;

            var deliverytimeDic = o2 as IDictionary<string, object>;


            s.DeliveryTime = TimeHelper.StringArrayToTimeArray(deliverytimeDic["delivery_time"].ToString());


            return s;
        }

        public static string FindByIdsSql(int[] ids)
        {
            string sql = string.Join(" ", BaseSelectSql(), "WHERE", "id IN({0})");
            string data = string.Join(",", ids);
            return string.Format(sql, data);
        }

        public static Tuple<string, dynamic> AddSql(Model.Supplier supplier)
        {
            const string sql = @"INSERT INTO supplier
	(name, address, tel, coordnate_longitude, coordnate_latitude, businesstime_start, businesstime_end, delivery_time, create_date, business_status)
	VALUES (@Name, @Address, @Tel, @CoordnateLongitude, @CoordnateLatitude, @BusinesstimeStart, @BusinesstimeEnd, @DeliveryTime, @CreateDate, @BusinessStatus);SELECT LAST_INSERT_ID()";

            return new Tuple<string, dynamic>(sql, InsertAndUpdateData(supplier));
        }

        public static Tuple<string, dynamic> UpdateSql(Model.Supplier supplier)
        {
            string sql = @"UPDATE supplier
	                    SET
		                    name=@Name,
		                    address=@Address,
		                    tel=@Tel,
		                    coordnate_longitude=@CoordnateLongitude,
		                    coordnate_latitude=@CoordnateLatitude,
		                    businesstime_start=@BusinesstimeStart,
		                    businesstime_end=@BusinesstimeEnd,
		                    delivery_time=@DeliveryTime,
		                    business_status=@BusinessStatus
	                    WHERE id=@Id";

            return new Tuple<string, dynamic>(sql, InsertAndUpdateData(supplier));
        }

        private static dynamic InsertAndUpdateData(Model.Supplier supplier)
        {
            var data = new
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Address = supplier.Address,
                Tel = supplier.Tel,
                CoordnateLongitude = NullHelper.IfNull(supplier.Coordinates, "", m => m.Longitude),
                CoordnateLatitude = NullHelper.IfNull(supplier.Coordinates, "", m => m.Latitude),
                BusinesstimeStart = NullHelper.IfNull(supplier.BusinessTime, "", m => NullHelper.IfNull(m.Start, "", t => t.ToString())),
                BusinesstimeEnd = NullHelper.IfNull(supplier.BusinessTime, "", m => NullHelper.IfNull(m.End, "", t => t.ToString())),
                DeliveryTime = NullHelper.IfNull(supplier.DeliveryTime, "", m => string.Join("|", m.Select(t => t.Start + "-" + t.End).ToArray())),
                CreateDate = supplier.CreateDate,
                BusinessStatus = supplier.BusinessStatus
            };

            return data;
        }

        public static String RemoveAllSql()
        {
            return "DELETE FROM supplier";
        }
        public static Tuple<string, dynamic> Remove(int id)
        {
            string sql = string.Join(" ", RemoveAllSql(), "WHERE", "id=@Id");

            return new Tuple<string, dynamic>(sql, new { Id = id });
        }

        public static Tuple<string, dynamic> FindByIdSql(int id)
        {
            string sql = string.Join(" ", BaseSelectSql(), "WHERE", "id=@Id");

            return new Tuple<string, dynamic>(sql, new { Id = id });
        }

        public static Tuple<string, string,dynamic> Select(int pageIndex, int pageSize)
        {
            string sqlcount = "SELECT COUNT(*) AS Count FROM supplier;";

            string selectsql = string.Join(" ", BaseSelectSql(), "ORDER BY id DESC", "LIMIT @Limit OFFSET @Offset;");

            return new Tuple<string, string, dynamic>(sqlcount, selectsql, new
            {
                Limit = pageSize,
                Offset = (pageIndex - 1) * pageSize
            });
        }
    }
}
