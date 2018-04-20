using System;
using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers
{
    [TestFixture]
    public class IdentificationLineParserTest
    {
        [Test]
        public void TestSample1()
        {
            var parser = new IdentificationLineParser();

            var sample = "0000018011520105        0938409934CODELICIOUS               GEBABEBB   09029308273 00001          984309          834080       2";

            Assert.IsTrue(parser.CanAcceptString(sample));

            var result = (IdentificationLine)parser.Parse(sample);

            Assert.AreEqual(new DateTime(2015, 01, 18), result.CreationDate.Value);
            Assert.AreEqual("201", result.BankIdentificationNumber.Value);
            Assert.AreEqual("05", result.ApplicationCode.Value);
            Assert.AreEqual(false, result.IsDuplicate);
            Assert.AreEqual("0938409934", result.FileReference.Value);
            Assert.AreEqual("CODELICIOUS", result.AccountName.Value);
            Assert.AreEqual("GEBABEBB", result.AccountBic.Value);
            Assert.AreEqual("09029308273", result.AccountCompanyIdentificationNumber.Value);
            Assert.AreEqual("00001", result.ExternalApplicationCode.Value);
            Assert.AreEqual("984309", result.TransactionReference.Value);
            Assert.AreEqual("834080", result.RelatedReference.Value);
            Assert.AreEqual("2", result.VersionCode.Value);
        }
    }
}