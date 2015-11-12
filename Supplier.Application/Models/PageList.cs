using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Application.Models
{
    /// <summary>
    /// 分页集合封装
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageList<T>
    {
        public int TotalRows
        {
            get;
            set;
        }
        public List<T> Collections
        {
            get;
            set;
        }
    }
}
