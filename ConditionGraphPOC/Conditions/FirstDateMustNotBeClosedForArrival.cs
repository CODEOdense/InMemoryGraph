using ConditionGraphPOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionGraphPOC.Conditions
{
    public class FirstDateMustNotBeClosedForArrival : ISpecification<RateNode>
    {
        private Date _arrivalDay;

        public FirstDateMustNotBeClosedForArrival(Date arrivalDay)
        {
            if (arrivalDay == null) throw new ArgumentNullException("arrivalDay");
            _arrivalDay = arrivalDay;
        }


        public bool IsSatisfiedBy(RateNode candidate)
        {
            if (candidate == null)
                throw new ArgumentNullException("candidate");

            var date = candidate.Dates.SingleOrDefault(x => x.Date.Date.Equals(_arrivalDay));
            if (date == null)
                return false; //no such date

            return !date.IsClosedForArrival;
        }


    }
}
