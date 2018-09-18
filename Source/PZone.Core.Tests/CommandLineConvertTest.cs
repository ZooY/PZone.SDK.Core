using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PZone.Core.Tests
{
    [TestClass]
    public class CommandLineConvertTest
    {
        [TestMethod]
        public void DeserializeObject()
        {
            var commandLine = "s=c:\\\\Users\\Admin\\Desktop\\Logo.jpg r=c:\\\\Users\\Admin\\Desktop\\Logo-sm.jpg h=40";
            var resizeProperties = CommandLineConvert.DeserializeObject<ResizeProperties>(commandLine);
            Assert.AreEqual("c:\\\\Users\\Admin\\Desktop\\Logo.jpg", resizeProperties.SourceFileName);
            Assert.AreEqual("c:\\\\Users\\Admin\\Desktop\\Logo-sm.jpg", resizeProperties.ResultFileName);
            Assert.AreEqual(40, resizeProperties.Height);
        }


        public class ResizeProperties
        {
            [CommandLineProperty("s")]
            public string SourceFileName { get; set; }

            [CommandLineProperty("r")]
            public string ResultFileName { get; set; }

            [CommandLineProperty("w")]
            public int Width { get; set; }

            [CommandLineProperty("h")]
            public int Height { get; set; }
        }
    }
}