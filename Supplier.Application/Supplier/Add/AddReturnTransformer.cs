using Easy.Domain.Application;
using Supplier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Application.Supplier.Add
{
    public class AddReturnTransformer : IReturnTransformer
    {
        public dynamic GetValue(Easy.Domain.Application.ReturnContext context, object data)
        {
            Model.Supplier supplier = data as Model.Supplier;

            if (supplier.GetBrokenRules().Count > 0)
            {
                return new ResultWithData<int>(ResultStatus.Error, 0, supplier.GetBrokenRules()[0].Description);
            }
            return new ResultWithData<int>(ResultStatus.Ok, supplier.Id);
        }

        public bool IsMapped(Easy.Domain.Application.ReturnContext context)
        {
            return true;
        }
    }
}
