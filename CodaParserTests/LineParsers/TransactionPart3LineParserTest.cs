using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers;

[TestFixture]
public class TransactionPart3LineParserTest
{
    [Test]
    public void TestSample1()
    {
        var parser = new TransactionPart3LineParser();

        var sample = "2300010000BE54805480215856                  EURBVBA.BAKKER PIET                         MESSAGE                              0 1";

        Assert.That(parser.CanAcceptString(sample), Is.True);

        var result = (TransactionPart3Line)parser.Parse(sample);

        Assert.That(result.SequenceNumber.Value, Is.EqualTo(1));
        Assert.That(result.SequenceNumberDetail.Value, Is.EqualTo(0));
        Assert.That(result.OtherAccountNumberAndCurrency.Value, Is.EqualTo("BE54805480215856                  EUR"));
        Assert.That(result.OtherAccountName.Value, Is.EqualTo("BVBA.BAKKER PIET"));
        Assert.That(result.Message.Value, Is.EqualTo(" MESSAGE "));
    }
}