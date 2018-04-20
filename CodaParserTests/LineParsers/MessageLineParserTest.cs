using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers
{
    [TestFixture]
    internal class MessageLineParserTest
    {
        [Test]
        public void TestSample1()
        {
            var parser = new MessageLineParser();

            var sample = "4 00010005                      THIS IS A PUBLIC MESSAGE                                                                       0";

            Assert.IsTrue(parser.CanAcceptString(sample));

            var result = (MessageLine)parser.Parse(sample);

            Assert.AreEqual(1, result.SequenceNumber.Value);
            Assert.AreEqual(5, result.SequenceNumberDetail.Value);
            Assert.AreEqual("THIS IS A PUBLIC MESSAGE ", result.Content.Value);
        }

        [Test]
        public void TestSample2()
        {
            var parser = new MessageLineParser();

            var sample = "4 00020000                                              ACCOUNT INFORMATION                                                    1";

            Assert.IsTrue(parser.CanAcceptString(sample));

            var result = (MessageLine)parser.Parse(sample);

            Assert.AreEqual(2, result.SequenceNumber.Value);
            Assert.AreEqual(0, result.SequenceNumberDetail.Value);
            Assert.AreEqual(" ACCOUNT INFORMATION ", result.Content.Value);
        }
    }
}