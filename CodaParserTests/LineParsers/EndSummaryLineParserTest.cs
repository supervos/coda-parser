using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers
{
    [TestFixture]
    public class EndSummaryLineParserTest
    {
        [Test]
        public void TestSample1()
        {
            var parser = new EndSummaryLineParser();

            var sample = "9               000015000000016837520000000003967220                                                                           1";

            Assert.IsTrue(parser.CanAcceptString(sample));

            var result = (EndSummaryLine)parser.Parse(sample);

            Assert.AreEqual(16837.520m, result.DebetAmount.Value);
            Assert.AreEqual(3967.220m, result.CreditAmount.Value);
        }
    }
}