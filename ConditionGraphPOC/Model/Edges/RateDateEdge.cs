using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionGraphPOC.Model.Edges
{
    public class RateDateEdge
    {
        public readonly RateNode Rate;
        public readonly DateNode Date;

        public RateDateEdge(RateNode rate, DateNode date)
        {
            Rate = rate;
            Date = date;
        }
    }
}
