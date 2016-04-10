using ConditionGraphPOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionGraphPOC.Conditions
{
    public class RateCanBeUsedForRoomstay : ISpecification<RateNode>
    {
        private Date _arrival;
        private Date _departure;

        public RateCanBeUsedForRoomstay(Date arrival, Date departure)
        {
            _arrival = arrival;
            _departure = departure;
        }

        public bool IsSatisfiedBy(RateNode candidate)
        {
            return new AndSpecification<RateNode>(
                    new RateMustApplyForAllDatesInPeriod(_arrival, _departure), 
                    new FirstDateMustNotBeClosedForArrival(_arrival))
                .IsSatisfiedBy(candidate);
        }
    }
}
