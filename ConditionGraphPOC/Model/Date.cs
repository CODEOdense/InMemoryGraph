using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionGraphPOC.Model
{
    public class Date : IComparable<Date>
    {
        public readonly int Year;
        public readonly int Month;
        public readonly int Day;

        public readonly int CompareValue;

        public static bool operator >(Date d1, Date d2)
        {
            return d1.CompareTo(d2) > 0;
        }

        public static bool operator <(Date d1, Date d2)
        {
            return d1.CompareTo(d2) < 0;
        }

        public Date(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
            CompareValue = (year * 1000) + (month * 100) + day;
        }

        public IEnumerable<Date> GetDatesInPeriod(Date to)
        {
            if (to < this) throw new InvalidOperationException("\"To\" must be after");

            var days = to.Day - this.Day;

            for (int i = 0; i <= days; i++)
            {
                yield return new Date(Year, Month, Day + i);
            }
        }

        public int CompareTo(Date other)
        {
            return CompareValue.CompareTo(other.CompareValue);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Date;
            return other != null && other.CompareValue == CompareValue;
        }

        public override int GetHashCode()
        {
            return CompareValue;
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}/{2}", Year, Month, Day);
        }

    }
}
