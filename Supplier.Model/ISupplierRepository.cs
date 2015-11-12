using Easy.Domain.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Model
{
    public interface ISupplierRepository : IRepository<Supplier, int>
    {
        /// <summary>
        /// 分页查询餐厅列表
        /// </summary>
        /// <param name="pageSize">每页返回的记录条数</param>
        /// <param name="pageIndex">起始页</param>
        /// <param name="totalRows">总记录数</param>
        /// <returns></returns>
        IEnumerable<Supplier> Select(int pageSize, int pageIndex, out int totalRows);
        /// <summary>
        /// 根据餐厅ID查询餐厅列表
        /// </summary>
        /// <param name="supplierIds">餐厅ID List</param>
        /// <returns></returns>
        IEnumerable<Supplier> FindByIds(int[] supplierIds);
    }
}
