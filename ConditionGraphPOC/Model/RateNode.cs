using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionGraphPOC.Model
{
    public class RateNode
    {
        public readonly string RateCode;
        private RateForDateEdge[] _dates;
        public IEnumerable<RateForDateEdge> Dates { get { return _dates; } }

        public RateNode(string rateCode, RateForDateEdge[] dates = null)
        {
            if (rateCode == null) throw new ArgumentNullException("rateCode");
            RateCode = rateCode;
            _dates = dates ?? new RateForDateEdge[0];
        }

        public void AddDateEdge(RateForDateEdge d)
        {
            _dates = Dates.Concat(Enumerable.Repeat(d, 1)).ToArray();
        }
    }
}
