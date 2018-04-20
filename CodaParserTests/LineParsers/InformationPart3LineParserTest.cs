using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers
{
    [TestFixture]
    public class InformationPart3LineParserTest
    {
        [Test]
        public void TestSample1()
        {
            var parser = new InformationPart3LineParser();

            var sample = "3300010001SOME INFORMATION ABOUT THIS TRANSACTION                                                                            0 0";

            Assert.IsTrue(parser.CanAcceptString(sample));

            var result = (InformationPart3Line)parser.Parse(sample);

            Assert.AreEqual(1, result.SequenceNumber.Value);
            Assert.AreEqual(1, result.SequenceNumberDetail.Value);
            Assert.AreEqual("SOME INFORMATION ABOUT THIS TRANSACTION ", result.Message.Value);
        }
    }
}