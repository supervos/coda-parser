using System;
using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers
{
    [TestFixture]
    internal class InitialStateLineParserTest
    {
        [Test]
        public void TestAccountIsIbanIsSetCorrectly()
        {
            var parser = new InitialStateLineParser();

            var sample = "13155001548226815 EUR0BE                  0000000004004100241214CODELICIOUS               PROFESSIONAL ACCOUNT               255";

            Assert.IsTrue(parser.CanAcceptString(sample));

            var result = (InitialStateLine)parser.Parse(sample);

            Assert.AreEqual(true, result.Account.Number.IsIbanNumber);
        }

        [Test]
        public void TestSample1()
        {
            var parser = new InitialStateLineParser();

            var sample = "10155001548226815 EUR0BE                  0000000004004100241214CODELICIOUS               PROFESSIONAL ACCOUNT               255";

            Assert.IsTrue(parser.CanAcceptString(sample));

            var result = (InitialStateLine)parser.Parse(sample);

            Assert.AreEqual("0", result.Account.NumberType.Value);
            Assert.AreEqual(155, result.StatementSequenceNumber.Value);
            Assert.AreEqual("001548226815", result.Account.Number.Value);
            Assert.AreEqual("EUR", result.Account.Currency.CurrencyCode);
            Assert.AreEqual("BE", result.Account.Country.CountryCode);
            Assert.AreEqual(false, result.Account.Number.IsIbanNumber);
            Assert.AreEqual(4004.100, result.Balance.Value);
            Assert.AreEqual(new DateTime(2014, 12, 24), result.Date.Value);
            Assert.AreEqual("CODELICIOUS", result.Account.Name.Value);
            Assert.AreEqual("PROFESSIONAL ACCOUNT", result.Account.Description.Value);
            Assert.AreEqual(255, result.PaperStatementSequenceNumber.Value);
        }
    }
}