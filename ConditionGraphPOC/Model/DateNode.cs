using ConditionGraphPOC.Model.Edges;
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
        private RateDateEdge[] _rates;
        public IEnumerable<RateDateEdge> Rates { get { return _rates; } }

        public DateNode(Date date, RateDateEdge[] rates)
        {
            if (date == null) throw new ArgumentNullException("date");
            if (rates == null) throw new ArgumentNullException("rates");
            Date = date;
            _rates = rates;
        }

        public DateNode(Date date) : this(date, new RateDateEdge[0]) { }

        public void AddRate(RateNode r)
        {
            var edge = new RateDateEdge(r, this);
            AddRateEdge(edge);
            r.AddDateEdge(edge);
        }

        public void AddRateEdge(RateDateEdge e)
        {
            if (e.Date != this)
                throw new InvalidOperationException("That date is not me!!");

            _rates = Rates.Concat(Enumerable.Repeat<RateDateEdge>(e, 1)).ToArray();
        }
    }
}
