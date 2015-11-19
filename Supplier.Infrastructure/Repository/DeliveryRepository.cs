using System;
using System.Collections.Generic;
using Dapper;
using Easy.Domain.RepositoryFramework;
using Supplier.Model;

namespace Supplier.Infrastructure.Repository
{
    public class DeliveryRepository : IDeliveryRepository, IDao
    {
        public Delivery FindBy(int key)
        {
            return null;
        }

        public IList<Delivery> FindAll()
        {
            return null;
        }

        public void Add(Delivery item)
        {
            
        }

        public void Update(Delivery item)
        {
            
        }

        public void Remove(Delivery item)
        {
            
        }

        public void RemoveAll()
        {
            
        }

        public IEnumerable<Delivery> FindByIds(int[] deliveryIds)
        {
            if (deliveryIds == null || deliveryIds.Length == 0)
            {
                return new List<Model.Delivery>(0);
            }

            using (var conn = Database.Open())
            {
                string ids = string.Join(",", deliveryIds);
                //in查询，不能使用参数化，会自动加上''
                //string sql = @"select * from delivery where id in (@id)";
                //var model = conn.Query<Model.Delivery>(sql,
                //    new
                //    {
                //        id = ids
                //    });

                string sql = @"select * from delivery where id in ({0})";
                sql = string.Format(sql, ids);
                var model = conn.Query<Model.Delivery>(sql,
                    new
                    {
                        id = ids
                    });

                return model;
            }
        }
    }
}
