using ConditionGraphPOC.Model.Edges;
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
        private RateDateEdge[] _dates;
        public IEnumerable<RateDateEdge> Dates { get { return _dates; } }

        public RateNode(string rateCode, RateDateEdge[] dates)
        {
            if (rateCode == null) throw new ArgumentNullException("rateCode");
            if (dates == null) throw new ArgumentNullException("dates");
            RateCode = rateCode;
            _dates = dates;
        }

        public RateNode(string rateCode) : this(rateCode, new RateDateEdge[0]) { }

        public void AddDate(DateNode d)
        {
            var edge = new RateDateEdge(this, d);
            AddDateEdge(edge);
            d.AddRateEdge(edge);
        }

        public void AddDateEdge(RateDateEdge e)
        {
            if (e.Rate != this)
                throw new InvalidOperationException("That rate is not me!!");

            _dates = Dates.Concat(Enumerable.Repeat<RateDateEdge>(e, 1)).ToArray();
        }
    }
}
