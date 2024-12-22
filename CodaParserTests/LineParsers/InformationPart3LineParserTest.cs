using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers;

[TestFixture]
public class InformationPart3LineParserTest
{
    [Test]
    public void TestSample1()
    {
        var parser = new InformationPart3LineParser();

        var sample = "3300010001SOME INFORMATION ABOUT THIS TRANSACTION                                                                            0 0";

        Assert.That(parser.CanAcceptString(sample), Is.True);

        var result = (InformationPart3Line)parser.Parse(sample);

        Assert.That(result.SequenceNumber.Value, Is.EqualTo(1));
        Assert.That(result.SequenceNumberDetail.Value, Is.EqualTo(1));
        Assert.That(result.Message.Value, Is.EqualTo("SOME INFORMATION ABOUT THIS TRANSACTION "));
    }
}