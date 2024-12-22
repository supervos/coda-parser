using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers;

[TestFixture]
public class EndSummaryLineParserTest
{
    [Test]
    public void TestSample1()
    {
        var parser = new EndSummaryLineParser();

        var sample = "9               000015000000016837520000000003967220                                                                           1";

        Assert.That(parser.CanAcceptString(sample), Is.True);

        var result = (EndSummaryLine)parser.Parse(sample);

        Assert.That(result.DebetAmount.Value, Is.EqualTo(16837.520m));
        Assert.That(result.CreditAmount.Value, Is.EqualTo(3967.220m));
    }
}