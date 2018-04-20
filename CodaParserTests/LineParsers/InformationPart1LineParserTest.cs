using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

[TestFixture]
public class InformationPart1LineParserTest
{
    [Test]
    public void TestSample1()
    {
        var parser = new InformationPart1LineParser();
        var sample = "31000100010007500005482        004800001001BVBA.BAKKER PIET                                                                  1 0";

        Assert.IsTrue(parser.CanAcceptString(sample));

        var result = (InformationPart1Line)parser.Parse(sample);

        Assert.AreEqual(1, result.SequenceNumber.Value);
        Assert.AreEqual(1, result.SequenceNumberDetail.Value);
        Assert.AreEqual("0007500005482", result.BankReference.Value);
        Assert.AreEqual("0", result.TransactionCode.Type.Value);
        Assert.AreEqual("04", result.TransactionCode.Family.Value);
        Assert.AreEqual("80", result.TransactionCode.Operation.Value);
        Assert.AreEqual("000", result.TransactionCode.Category.Value);
        Assert.IsNull(result.MessageOrStructuredMessage.Message);
        Assert.IsNotNull(result.MessageOrStructuredMessage.StructuredMessage);
        Assert.AreEqual("001", result.MessageOrStructuredMessage.StructuredMessage.StructuredMessageType);
        Assert.AreEqual("BVBA.BAKKER PIET                                                      ", result.MessageOrStructuredMessage.StructuredMessage.StructuredMessageFull);
        Assert.IsEmpty(result.MessageOrStructuredMessage.StructuredMessage.Value);
    }

    [Test]
    public void TestSampleWithAccents()
    {
        var parser = new InformationPart1LineParser();
        var sample = "31000100073403076534383000143  335370000ekeningING Plus BE12 3215 1548 2121 EUR Compte à vue BE25 3215 2158 2315             0 1";

        Assert.IsTrue(parser.CanAcceptString(sample));
        var result = (InformationPart1Line)parser.Parse(sample);

        Assert.AreEqual(1, result.SequenceNumber.Value);
        Assert.AreEqual("ekeningING Plus BE12 3215 1548 2121 EUR Compte à vue BE25 3215 2158 2315 ", result.MessageOrStructuredMessage.Message.Value);
    }
}