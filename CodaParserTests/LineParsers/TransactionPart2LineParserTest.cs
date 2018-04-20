using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

[TestFixture]
public class TransactionPart2LineParserTest
{
    [Test]
    public void TestSample1()
    {
        var parser = new TransactionPart2LineParser();

        var sample = "2200010000  ANOTHER MESSAGE                                           54875                       GEBCEEBB                   1 0";

        Assert.IsTrue(parser.CanAcceptString(sample));

        var result = (TransactionPart2Line)parser.Parse(sample);

        Assert.AreEqual(1, result.SequenceNumber.Value);
        Assert.AreEqual(0, result.SequenceNumberDetail.Value);
        Assert.AreEqual(" ANOTHER MESSAGE ", result.Message.Value);
        Assert.AreEqual("54875", result.ClientReference.Value);
        Assert.AreEqual("GEBCEEBB", result.OtherAccountBic.Value);
        Assert.AreEqual("", result.CategoryPurpose.Value);
        Assert.AreEqual("", result.Purpose.Value);
    }
}