using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Model
{
    /// <summary>
    /// 坐标值对象
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// 初始化坐标
        /// </summary>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        public Coordinates(string longitude, string latitude)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
        }

        /// <summary>
        /// 经度
        /// </summary>
        public String Longitude
        {
            get;
            private set;
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public String Latitude
        {
            get;
            private set;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj as Coordinates == null)
            {
                return false;
            }
            Coordinates c = obj as Coordinates;

            if (this.Latitude == c.Latitude && this.Longitude == c.Longitude)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.Latitude.GetHashCode() ^ this.Longitude.GetHashCode();
        }
    }
}
