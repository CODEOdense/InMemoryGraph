using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionGraphPOC.Model
{
    public class DateNode
    {
        public readonly Date Date;
        private RateForDateEdge[] _rates;

        public IEnumerable<RateForDateEdge> Rates { get { return _rates; } }

        public DateNode(Date date, RateForDateEdge[] rates)
        {
            if (date == null) throw new ArgumentNullException("date");
            if (rates == null) throw new ArgumentNullException("rates");
            Date = date;
            _rates = rates;
        }

        public DateNode(Date date) : this(date, new RateForDateEdge[0]) { }


        public void AddRateEdge(RateForDateEdge e)
        {
            _rates = Rates.Concat(Enumerable.Repeat(e, 1)).ToArray();
        }
    }
}
