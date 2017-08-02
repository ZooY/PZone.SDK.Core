using Microsoft.VisualStudio.TestTools.UnitTesting;
using PZone.Helpers;


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
    }
}