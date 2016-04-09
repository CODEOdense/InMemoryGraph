using ConditionGraphPOC.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionGraphPOC
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void DateComparrison()
        {
            var a = new Date(2001, 2, 3);
            var b = new Date(2001, 2, 4);
            var c = new Date(2002, 1, 1);

            Assert.IsTrue(a < b);
            Assert.IsTrue(b > a);
            Assert.IsTrue(c > a);
        }

        [Test]
        public void RateDateEdge()
        {
            var jan1 = new DateNode(new Date(2016, 1, 1));
            var jan2 = new DateNode(new Date(2016, 1, 2));
            var jan3 = new DateNode(new Date(2016, 1, 3));

            var dbl = new RateNode("DBL");
            var sgl = new RateNode("SGL");

            dbl.AddDate(jan1); dbl.AddDate(jan2);
            sgl.AddDate(jan2); jan3.AddRate(sgl);

            CollectionAssert.AreEquivalent(dbl.Dates.Select(e => e.Date), new[] { jan1, jan2 });
            CollectionAssert.AreEquivalent(sgl.Dates.Select(e => e.Date), new[] { jan2, jan3 });
            CollectionAssert.AreEquivalent(jan1.Rates.Select(e => e.Rate), new[] { dbl });
            CollectionAssert.AreEquivalent(jan2.Rates.Select(e => e.Rate), new[] { sgl, dbl});
            CollectionAssert.AreEquivalent(jan3.Rates.Select(e => e.Rate), new[] { sgl});
        }

        [Test]
        public void GetRates_WhenRateHasAllDatesInPeriod_ReturnsRate()
        {
            var dates = new[] { new DateNode(new Date(2016, 1, 1)), new DateNode(new Date(2016, 1, 2)), new DateNode(new Date(2016, 1, 3)), new DateNode(new Date(2016, 1, 4)) };
            var dbl = new RateNode("DBL");
            var sgl = new RateNode("SGL");
            //all dates for DBL
            foreach (var d in dates) { dbl.AddDate(d); }
            //only 1->3 for sgl
            sgl.AddDate(dates[0]); sgl.AddDate(dates[1]); sgl.AddDate(dates[2]);

            var sut = new RateProvider(dates, new[] { dbl });


            var rates = sut.GetRates(new Date(2016, 1, 1), new Date(2016, 1, 3));

            CollectionAssert.AreEquivalent(new[] { "DBL","SGL" }, rates);
        }

        [Test]
        public void GetRates_WhenRateDoesNotHaveAllDatesInPeriod_DoesNotReturnsRate()
        {
            var dates = new[] { new DateNode(new Date(2016, 1, 1)), new DateNode(new Date(2016, 1, 2)), new DateNode(new Date(2016, 1, 3)), new DateNode(new Date(2016, 1, 4)) };
            var dbl = new RateNode("DBL");
            var sgl = new RateNode("SGL");
            //only 1 & 3 for dbl
            dbl.AddDate(dates[0]); dbl.AddDate(dates[2]);
            //only 1->3 for sgl
            sgl.AddDate(dates[0]); sgl.AddDate(dates[1]); sgl.AddDate(dates[2]);

            var sut = new RateProvider(dates, new[] { dbl });


            var rates = sut.GetRates(new Date(2016, 1, 1), new Date(2016, 1, 3));

            CollectionAssert.AreEquivalent(new[] { "SGL" }, rates);
        }

        [Test]
        public void Date_GetDatesInPeriod()
        {
            var a = new Date(2016, 1, 10);
            var b = new Date(2016, 1, 15);
            var expected = new[] {
                new Date(2016, 1, 10),
                new Date(2016, 1, 11),
                new Date(2016, 1, 12),
                new Date(2016, 1, 13),
                new Date(2016, 1, 14),
                new Date(2016, 1, 15)
            };


            var result = a.GetDatesInPeriod(b);

            CollectionAssert.AreEqual(expected,result);


        }
    }
    


   
}
