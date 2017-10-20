using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PZone.Logging;


namespace PZone.Core.Tests.Logging
{
    [TestClass]
    public class LoggerBaseTests
    {
        public class TestLogger : LoggerBase
        {
            public TestLogger(string correlationId, string appId, string appVersion) : base(correlationId, appId, appVersion)
            {
            }


            protected override void WriteToLog(LogLevel level, string message, object data, Exception exception)
            {
                throw new NotImplementedException();
            }


            public static string BuildJsonTest(string appId, string appVersion, string message, object data, Exception exception)
            {
                return BuildJson(appId, appVersion, message, data, exception);
            }
        }


        [TestMethod]
        public void BuildJsonFullData()
        {
            var expected = @"{
  ""AppId"": ""Test"",
  ""AppVersion"": ""1.0"",
  ""Message"": ""Test Message"",
  ""Data"": ""Test Data String"",
  ""Exception"": {
    ""ClassName"": ""System.Exception"",
    ""Message"": ""Test Excaption"",
    ""Data"": null,
    ""InnerException"": null,
    ""HelpURL"": null,
    ""StackTraceString"": null,
    ""RemoteStackTraceString"": null,
    ""RemoteStackIndex"": 0,
    ""ExceptionMethod"": null,
    ""HResult"": -2146233088,
    ""Source"": null,
    ""WatsonBuckets"": null
  }
}";
            var actual = TestLogger.BuildJsonTest("Test", "1.0", "Test Message", "Test Data String", new Exception("Test Excaption"));
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void BuildJsonMessage()
        {
            var expected = @"{
  ""Message"": ""Test Message""
}";
            var actual = TestLogger.BuildJsonTest(null, null, "Test Message", null, null);
            Assert.AreEqual(expected, actual);
        }
    }
}