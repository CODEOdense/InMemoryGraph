using ConditionGraphPOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionGraphPOC.Conditions
{
    public class RateMustApplyForAllDatesInPeriod : ISpecification<RateNode>
    {
        Period DesiredPeriod;

        public RateMustApplyForAllDatesInPeriod(Date arrivalDate, Date departureDate)
        {
            DesiredPeriod = new Period(arrivalDate.GetDatesInPeriod(departureDate).ToArray());
        }

        public bool IsSatisfiedBy(RateNode candidate)
        {
            var actual = new Period(candidate.Dates.Select(e=>e.Date.Date).Intersect(DesiredPeriod.DatesInPeriod).ToArray());
            return actual.Equals(DesiredPeriod);
        }
    }
}
