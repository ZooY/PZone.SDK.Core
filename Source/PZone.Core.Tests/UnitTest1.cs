using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PZone.Core.Tests
{
    [TestClass]
    public class TimeUnitTest
    {
        [TestMethod]
        public void Name()
        {
            var culture = new CultureInfo("ru");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            var actual = TimeUnit.Month.GetName();
            Assert.AreEqual("Месяц", actual);

            culture = new CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            actual = TimeUnit.Month.GetName();
            Assert.AreEqual("Month", actual);
        }
    }
}
