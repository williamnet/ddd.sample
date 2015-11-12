using Supplier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Easy.Public;
using Easy.Domain.RepositoryFramework;

namespace Supplier.Infrastructure.Repository
{
    public class SupplierRepository : ISupplierRepository, IDao
    {
        private static readonly EntityPropertyHelper<Model.Supplier> propertyHelper = new EntityPropertyHelper<Model.Supplier>();

        public IEnumerable<Model.Supplier> Select(int pageSize, int pageIndex, out int totalRows)
        {
            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }
            if (pageSize <= 0 || pageSize > 100)
            {
                pageSize = 100;
            }

            using (var conn = Database.Open())
            {
                var tuple = Sql.Select(pageIndex, pageSize);

                SqlMapper.GridReader reader = conn.QueryMultiple(tuple.Item1 + tuple.Item2, (object)tuple.Item3);

                var result = reader.Read<object>().First() as IDictionary<string,object>;
                totalRows = Convert.ToInt32(result["Count"]);

                return reader.Read<Model.Supplier, object, object, object, Model.Supplier>(Sql.SelectConvert, splitOn: "split");
            }
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="item"></param>
        public void Add(Model.Supplier item)
        {
            using (var conn = Database.Open())
            {
                var tuple = Sql.AddSql(item);
                int id = conn.ExecuteScalar<int>(tuple.Item1, (object)tuple.Item2);
                propertyHelper.SetValue(m => m.Id, item, id);
            }
        }

        public IList<Model.Supplier> FindAll()
        {
            throw new NotImplementedException();
        }

        public Model.Supplier FindBy(int key)
        {
            using (var conn = Database.Open())
            {
                var tuple = Sql.FindByIdSql(key);

                return conn.Query<Model.Supplier, object, object, object, Model.Supplier>(tuple.Item1, Sql.SelectConvert, (object)tuple.Item2, splitOn: "split").SingleOrDefault();
            }
        }

        public void Remove(Model.Supplier item)
        {
            using (var conn = Database.Open())
            {
                var tuple = Sql.Remove(item.Id);
                conn.Execute(tuple.Item1, (object)tuple.Item2);
            }
        }

        public void RemoveAll()
        {
            using (var conn = Database.Open())
            {
                string sql = Sql.RemoveAllSql();
                conn.Execute(sql);
            }
        }

        public void Update(Model.Supplier item)
        {
            using (var conn = Database.Open())
            {
                var tuple = Sql.UpdateSql(item);
                conn.Execute(tuple.Item1, (object)tuple.Item2);
            }
        }


        public IEnumerable<Model.Supplier> FindByIds(int[] supplierIds)
        {
            if (supplierIds == null || supplierIds.Length == 0)
            {
                return new List<Model.Supplier>(0);
            }

            using (var conn = Database.Open())
            {
                string sql = Sql.FindByIdsSql(supplierIds);
                return conn.Query<Model.Supplier, object, object, object, Model.Supplier>(sql, Sql.SelectConvert, splitOn: "split");
            }
        }
    }
}
