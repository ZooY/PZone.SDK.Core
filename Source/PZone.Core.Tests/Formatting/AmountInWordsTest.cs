using Microsoft.VisualStudio.TestTools.UnitTesting;
using PZone.Formatting;


namespace PZone.Core.Tests.Formatting
{
    [TestClass]
    public class AmountInWordsTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var aiw = new AmountInWords();
            var actual = aiw.Execute("123456789.11", Currencies.RUB);
            Assert.AreEqual("сто двадцать три миллиона четыреста пятьдесят шесть тысяч семьсот восемьдесят девять рублей 11 копеек", actual);

            actual = aiw.Execute("12345678.12", Currencies.RUB);
            Assert.AreEqual("двенадцать миллионов триста сорок пять тысяч шестьсот семьдесят восемь рублей 12 копеек", actual);

            actual = aiw.Execute("1212567.23", Currencies.RUB);
            Assert.AreEqual("один милилон двести двенадцать тысяч пятьсот шестьдесят семь рублей 23 копейки", actual);

            actual = aiw.Execute("1234567.11", Currencies.RUB);
            Assert.AreEqual("один милилон двести тридцать четыре тысячи пятьсот шестьдесят семь рублей 11 копеек", actual);

            actual = aiw.Execute("21.11", Currencies.RUB);
            Assert.AreEqual("двадцать один рубль 11 копеек", actual);

            actual = aiw.Execute("1000.00", Currencies.RUB);
            Assert.AreEqual("одна тысяча рублей 0 копеек", actual);

            actual = aiw.Execute("25.11", Currencies.RUB);
            Assert.AreEqual("двадцать пять рублей 11 копеек", actual);

            actual = aiw.Execute("11.11", Currencies.RUB);
            Assert.AreEqual("одинадцать рублей 11 копеек", actual);

            actual = aiw.Execute("0.11", Currencies.RUB);
            Assert.AreEqual("ноль рублей 11 копеек", actual);

            actual = aiw.Execute("11.0", Currencies.RUB);
            Assert.AreEqual("одинадцать рублей 0 копеек", actual);

            actual = aiw.Execute("11.1", Currencies.RUB);
            Assert.AreEqual("одинадцать рублей 1 копейка", actual);

            actual = aiw.Execute("11.3", Currencies.RUB);
            Assert.AreEqual("одинадцать рублей 3 копейки", actual);

            actual = aiw.Execute("11", Currencies.RUB);
            Assert.AreEqual("одинадцать рублей 0 копеек", actual);

            actual = aiw.Execute(".0", Currencies.RUB);
            Assert.AreEqual("ноль рублей 0 копеек", actual);

            actual = aiw.Execute(".0", Currencies.RUB);
            Assert.AreEqual("ноль рублей 0 копеек", actual);

            actual = aiw.Execute("", Currencies.RUB);
            Assert.AreEqual("ноль рублей 0 копеек", actual);

            actual = aiw.Execute("11.3", Currencies.RUB, AmountInWordsOptions.None);
            Assert.AreEqual("одинадцать рублей три копейки", actual);

            actual = aiw.Execute("11.33", Currencies.RUB, AmountInWordsOptions.None);
            Assert.AreEqual("одинадцать рублей тридцать три копейки", actual);

            actual = aiw.Execute("11.12", Currencies.RUB, AmountInWordsOptions.None);
            Assert.AreEqual("одинадцать рублей двенадцать копеек", actual);

            actual = aiw.Execute("11.12", Currencies.RUB, AmountInWordsOptions.WholeOnly);
            Assert.AreEqual("одинадцать рублей", actual);

            actual = aiw.Execute("11.12", Currencies.RUB, AmountInWordsOptions.FractionalOnly);
            Assert.AreEqual("двенадцать копеек", actual);

            actual = aiw.Execute("", Currencies.RUB, AmountInWordsOptions.NumericWhole | AmountInWordsOptions.NumericFractional);
            Assert.AreEqual("0 рублей 0 копеек", actual);
        }
    }
}