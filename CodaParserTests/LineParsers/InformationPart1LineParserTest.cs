using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers;

[TestFixture]
public class InformationPart1LineParserTest
{
    [Test]
    public void TestSample1()
    {
        var parser = new InformationPart1LineParser();
        var sample = "31000100010007500005482        004800001001BVBA.BAKKER PIET                                                                  1 0";

        Assert.That(parser.CanAcceptString(sample), Is.True);

        var result = (InformationPart1Line)parser.Parse(sample);

        Assert.That(result.SequenceNumber.Value, Is.EqualTo(1));
        Assert.That(result.SequenceNumberDetail.Value, Is.EqualTo(1));
        Assert.That(result.BankReference.Value, Is.EqualTo("0007500005482"));
        Assert.That(result.TransactionCode.Type.Value, Is.EqualTo("0"));
        Assert.That(result.TransactionCode.Family.Value, Is.EqualTo("04"));
        Assert.That(result.TransactionCode.Operation.Value, Is.EqualTo("80"));
        Assert.That(result.TransactionCode.Category.Value, Is.EqualTo("000"));
        Assert.That(result.MessageOrStructuredMessage.Message, Is.Null);
        Assert.That(result.MessageOrStructuredMessage.StructuredMessage, Is.Not.Null);
        Assert.That(result.MessageOrStructuredMessage.StructuredMessage.StructuredMessageType, Is.EqualTo("001"));
        Assert.That(result.MessageOrStructuredMessage.StructuredMessage.StructuredMessageFull, Is.EqualTo("BVBA.BAKKER PIET                                                      "));
        Assert.That(result.MessageOrStructuredMessage.StructuredMessage.Value, Is.Empty);
    }

    [Test]
    public void TestSampleWithAccents()
    {
        var parser = new InformationPart1LineParser();
        var sample = "31000100073403076534383000143  335370000ekeningING Plus BE12 3215 1548 2121 EUR Compte à vue BE25 3215 2158 2315             0 1";

        Assert.That(parser.CanAcceptString(sample), Is.True);
        var result = (InformationPart1Line)parser.Parse(sample);

        Assert.That(result.SequenceNumber.Value, Is.EqualTo(1));
        Assert.That(result.MessageOrStructuredMessage.Message.Value, Is.EqualTo("ekeningING Plus BE12 3215 1548 2121 EUR Compte à vue BE25 3215 2158 2315 "));
    }
}