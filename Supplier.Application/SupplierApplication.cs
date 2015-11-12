using Easy.Domain.Application;
using Supplier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Application
{
    /// <summary>
    /// 餐厅应用服务
    /// </summary>
    public class SupplierApplication : BaseApplication
    {
        /// <summary>
        /// 创建餐厅
        /// </summary>
        /// <param name="model">餐厅信息</param>
        /// <returns></returns>
        public IReturn Add(AddSupplierModel model)
        {
            Model.Supplier supplier = model.ToSupplier();

            if (supplier.Validate())
            {
                Model.RepositoryRegistry.Supplier.Add(supplier);
            }
            return this.Write("Add", supplier);
        }
        /// <summary>
        /// 查询一个餐厅详细信息
        /// </summary>
        /// <param name="id">餐厅ID</param>
        /// <returns></returns>
        public IReturn FindById(int id)
        {
            Model.Supplier supplier = Model.RepositoryRegistry.Supplier.FindBy(id);
            return this.Write("FindById",supplier);
        }
        /// <summary>
        /// 查询餐厅列表
        /// </summary>
        /// <param name="pageSize">每页返回记录数</param>
        /// <param name="pageIndex">页码 ，起始页=1</param>
        /// <returns></returns>
        public IReturn Select(int pageSize = 20,int pageIndex = 1)
        {
            int totalRows = 0;
            IEnumerable<Model.Supplier> suppliers = Model.RepositoryRegistry.Supplier.Select(pageSize, pageIndex,out totalRows);

            return this.Write("Select", new PageList<Model.Supplier>() { TotalRows = totalRows, Collections = suppliers.ToList() });
        }
        /// <summary>
        /// 更新餐厅信息
        /// </summary>
        /// <param name="supplierId">餐厅ID</param>
        /// <param name="model">餐厅信息</param>
        /// <returns></returns>
        public IReturn Update(int supplierId, AddSupplierModel model)
        {
            Model.Supplier supplier = Model.RepositoryRegistry.Supplier.FindBy(supplierId);
            if (supplier != null)
            {
                model.ToSupplier(supplier);
                if (supplier.Validate())
                {
                    Model.RepositoryRegistry.Supplier.Update(supplier);
                }
            }
            return this.Write("Update", supplier);
        }
        /// <summary>
        /// 开始营业
        /// </summary>
        /// <param name="id">餐厅ID</param>
        /// <returns></returns>
        public IReturn Open(int id)
        {
            Model.Supplier supplier = Model.RepositoryRegistry.Supplier.FindBy(id);
            if (supplier != null)
            {
                supplier.Open();
                Model.RepositoryRegistry.Supplier.Update(supplier);
            }

            return this.Write("Open", supplier);
        }
        /// <summary>
        /// 停止营业
        /// </summary>
        /// <param name="id">餐厅ID</param>
        /// <returns></returns>
        public IReturn Close(int id)
        {
            Model.Supplier supplier = Model.RepositoryRegistry.Supplier.FindBy(id);
            if (supplier != null)
            {
                supplier.Close();
                Model.RepositoryRegistry.Supplier.Update(supplier);
            }

            return this.Write("Close", supplier);

        }
        /// <summary>
        /// 查询一批餐厅详细信息
        /// </summary>
        /// <param name="supplierIds">参餐ID集合</param>
        /// <returns></returns>
        public IReturn FindByIds(int[] supplierIds)
        {
            IEnumerable<Model.Supplier> supplier = Model.RepositoryRegistry.Supplier.FindByIds(supplierIds);

            return this.Write("FindByIds", supplier);
        }
    }
}
