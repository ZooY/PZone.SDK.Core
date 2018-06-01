using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PZone.Web;


namespace PZone.Core.Tests.Web
{
    [TestClass]
    public class QueryStringConvertTest
    {
        public class Request
        {
            public string Name { get; set; }
            public int? Age { get; set; }
            public int? PensionAge { get; set; }
            public int? PaymentPeriod { get; set; }
            public decimal? PensionAmount { get; set; }
            //[QueryStringConverter(typeof(StringEnumConverter))]
            public TimeUnit? ContributionPeriodicity { get; set; }
            public decimal? AccumulationPeriodProfit { get; set; }
        }


        [TestMethod]
        public void Serialize()
        {
            var request = new Request
            {
                Name = "Иванов",
                Age = 35,
                PensionAge = 55,
                PaymentPeriod = 5,
                PensionAmount = 10000.5M,
                ContributionPeriodicity = TimeUnit.Month,
                AccumulationPeriodProfit = 8
            };

            var actual = QueryStringConvert.SerializeObject(request);
            Debug.WriteLine(actual);
        }
    }
}