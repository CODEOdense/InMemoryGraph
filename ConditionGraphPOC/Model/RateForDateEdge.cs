using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionGraphPOC.Model
{
    public class RateForDateEdge
    {
        public readonly RateNode Rate;
        public readonly DateNode Date;

        public bool IsClosedForArrival = false; //public setter :/

        public RateForDateEdge(RateNode rate, DateNode date)
        {
            if (rate == null) throw new ArgumentNullException("rate");
            if (date== null) throw new ArgumentNullException("date");

            Rate = rate;
            Date = date;

            date.AddRateEdge(this);
            rate.AddDateEdge(this);
        }
    }
}
