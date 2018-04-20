using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

[TestFixture]
public class TransactionPart3LineParserTest
{
    [Test]
    public void TestSample1()
    {
        var parser = new TransactionPart3LineParser();

        var sample = "2300010000BE54805480215856                  EURBVBA.BAKKER PIET                         MESSAGE                              0 1";

        Assert.IsTrue(parser.CanAcceptString(sample));

        var result = (TransactionPart3Line)parser.Parse(sample);

        Assert.AreEqual(1, result.SequenceNumber.Value);
        Assert.AreEqual(0, result.SequenceNumberDetail.Value);
        Assert.AreEqual("BE54805480215856                  EUR", result.OtherAccountNumberAndCurrency.Value);
        Assert.AreEqual("BVBA.BAKKER PIET", result.OtherAccountName.Value);
        Assert.AreEqual(" MESSAGE ", result.Message.Value);
    }
}