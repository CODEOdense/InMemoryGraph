using ConditionGraphPOC.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionGraphPOC.Model
{
    public class RateProvider
    {
        private DateNode[] _dateNodes;
        private RateNode[] _rateNodes;

        public RateProvider(DateNode[] dateNodes, RateNode[] rateNodes)
        {
            _dateNodes = dateNodes;
            _rateNodes = rateNodes;
        }

        public string[] GetRates(Date arrivalDate, Date departureDate)
        {
            var canBeUsedForDate = new RateMustApplyForAllDatesInPeriod(arrivalDate, departureDate);
            var first = _dateNodes.FirstOrDefault(d => d.Date.Equals(arrivalDate));
            if (first == null)
            {
                return new string[0];
            }

            return first.Rates.Select(e => e.Rate).Where(canBeUsedForDate.IsSatisfiedBy).Select(compliant => compliant.RateCode).ToArray();


        }


    }
}
