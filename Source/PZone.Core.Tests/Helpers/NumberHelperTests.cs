//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using PZone.Helpers;


//namespace PZone.Core.Tests.Helpers
//{
//    [TestClass]
//    public class NumberHelperTests
//    {
//        [TestMethod()]
//        public void SplitTest()
//        {
//            string
//                fractional, // целая часть числа
//                whole; // дробная часть числа

//            NumberHelper.Split("11.11", out fractional, out whole);
//            Assert.AreEqual("11", fractional);
//            Assert.AreEqual("11", whole);

//            NumberHelper.Split("11.0", out fractional, out whole);
//            Assert.AreEqual("11", fractional);
//            Assert.AreEqual("0", whole);

//            NumberHelper.Split("0.11", out fractional, out whole);
//            Assert.AreEqual("0", fractional);
//            Assert.AreEqual("11", whole);

//            NumberHelper.Split("11", out fractional, out whole);
//            Assert.AreEqual("11", fractional);
//            Assert.AreEqual("0", whole);

//            NumberHelper.Split(".11", out fractional, out whole);
//            Assert.AreEqual("0", fractional);
//            Assert.AreEqual("11", whole);

//            NumberHelper.Split("", out fractional, out whole);
//            Assert.AreEqual("0", fractional);
//            Assert.AreEqual("0", whole);

//            NumberHelper.Split("000.000", out fractional, out whole);
//            Assert.AreEqual("000", fractional);
//            Assert.AreEqual("000", whole);

//            NumberHelper.Split("000.000", out fractional, out whole, NumberSplitOptions.RemoveWasteZeros);
//            Assert.AreEqual("0", fractional);
//            Assert.AreEqual("0", whole);

//            NumberHelper.Split("000", out fractional, out whole, NumberSplitOptions.RemoveWasteZeros);
//            Assert.AreEqual("0", fractional);
//            Assert.AreEqual("0", whole);

//            NumberHelper.Split(".000", out fractional, out whole, NumberSplitOptions.RemoveWasteZeros);
//            Assert.AreEqual("0", fractional);
//            Assert.AreEqual("0", whole);

//            NumberHelper.Split("000.0", out fractional, out whole, NumberSplitOptions.RemoveWasteZeros);
//            Assert.AreEqual("0", fractional);
//            Assert.AreEqual("0", whole);

//            NumberHelper.Split("010.00010", out fractional, out whole, NumberSplitOptions.RemoveWasteZeros);
//            Assert.AreEqual("10", fractional);
//            Assert.AreEqual("0001", whole);
//        }
//    }
//}