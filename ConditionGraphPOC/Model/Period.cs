using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionGraphPOC.Model
{
    public class Period
    {
        public readonly Date[] DatesInPeriod;

        public Period(Date[] dates)
        {
            if (dates == null) throw new ArgumentNullException("dates");

            //todo: check for holes!
            DatesInPeriod = dates;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Period;

            if (DatesInPeriod.Length != other.DatesInPeriod.Length)
                return false;

            foreach (var d in DatesInPeriod)
            {
                if (!other.DatesInPeriod.Contains(d))
                    return false;
            }

            return true;
        }

    }
}
