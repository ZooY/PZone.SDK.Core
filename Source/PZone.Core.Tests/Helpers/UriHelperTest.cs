using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PZone.Core.Tests.Helpers
{
    [TestClass]
    public class UriHelperTests
    {
        [TestMethod]
        public void Combine()
        {
            var expected = "http://domain.com/path/path/path/file.htm";
            var actual = UriHelper.Combine("http://domain.com/", "path", "/path/", "/path/", "/", "/file.htm");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AppendParameters()
        {
            var expected = "http://domain.com/path?param1=%d1%81%d1%82%d1%80%d0%be%d0%ba%d0%be%d0%b2%d0%be%d0%b5+%d0%b7%d0%bd%d0%b0%d1%87%d0%b5%d0%bd%d0%b8%d0%b5&param2=123&param3=http%3a%2f%2fqwe%2f";
            var actual = UriHelper.AppendParameters("http://domain.com/path", new Dictionary<string, object>()
            {
                { "param1", "строковое значение" },
                { "param2", 123 },
                { "param3", new Uri("http://qwe") }
            });
            Assert.AreEqual(expected, actual);
        }
    }
}