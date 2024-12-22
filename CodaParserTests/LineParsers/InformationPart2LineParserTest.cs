using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers;

[TestFixture]
public class InformationPart2LineParserTest
{
    [Test]
    public void TestSample1()
    {
        var parser = new InformationPart2LineParser();

        var sample = "3200010001MAIN STREET 928                    5480 SOME CITY                                                                  0 0";

        Assert.That(parser.CanAcceptString(sample), Is.True);

        var result = (InformationPart2Line)parser.Parse(sample);

        Assert.That(result.SequenceNumber.Value, Is.EqualTo(1));
        Assert.That(result.SequenceNumberDetail.Value, Is.EqualTo(1));
        Assert.That(result.Message.Value, Is.EqualTo("MAIN STREET 928                    5480 SOME CITY "));
    }
}