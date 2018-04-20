using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers
{
    [TestFixture]
    public class InformationPart2LineParserTest
    {
        [Test]
        public void TestSample1()
        {
            var parser = new InformationPart2LineParser();

            var sample = "3200010001MAIN STREET 928                    5480 SOME CITY                                                                  0 0";

            Assert.IsTrue(parser.CanAcceptString(sample));

            var result = (InformationPart2Line)parser.Parse(sample);

            Assert.AreEqual(1, result.SequenceNumber.Value);
            Assert.AreEqual(1, result.SequenceNumberDetail.Value);
            Assert.AreEqual("MAIN STREET 928                    5480 SOME CITY ", result.Message.Value);
        }
    }
}