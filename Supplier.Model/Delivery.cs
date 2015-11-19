using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Supplier.Model
{
    public class Delivery : EntityBase<int>
    {
        public Delivery()
        {
            
        }
        public int ID { set; get; }

        public string Name { set; get; }
        protected override BrokenRuleMessage GetBrokenRuleMessages()
        {
            return null;
        }

        public override bool Validate()
        {
            return true;
        }
    }
}
