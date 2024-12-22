using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers;

[TestFixture]
public class TransactionPart2LineParserTest
{
    [Test]
    public void TestSample1()
    {
        var parser = new TransactionPart2LineParser();

        var sample = "2200010000  ANOTHER MESSAGE                                           54875                       GEBCEEBB                   1 0";

        Assert.That(parser.CanAcceptString(sample), Is.True);

        var result = (TransactionPart2Line)parser.Parse(sample);

        Assert.That(result.SequenceNumber.Value, Is.EqualTo(1));
        Assert.That(result.SequenceNumberDetail.Value, Is.EqualTo(0));
        Assert.That(result.Message.Value, Is.EqualTo(" ANOTHER MESSAGE "));
        Assert.That(result.ClientReference.Value, Is.EqualTo("54875"));
        Assert.That(result.OtherAccountBic.Value, Is.EqualTo("GEBCEEBB"));
        Assert.That(result.CategoryPurpose.Value, Is.EqualTo(""));
        Assert.That(result.Purpose.Value, Is.EqualTo(""));
    }
}