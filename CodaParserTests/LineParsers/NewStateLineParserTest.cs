using System;
using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers;

[TestFixture]
public class NewStateLineParserTest
{
    [Test]
    public void TestSample1()
    {
        var parser = new NewStateLineParser();

        var sample = "8225001548226815 EUR0BE                  1000000500012100120515                                                                0";

        Assert.That(parser.CanAcceptString(sample), Is.True);

        var result = (NewStateLine)parser.Parse(sample);

        Assert.That(result.StatementSequenceNumber.Value, Is.EqualTo(225));
        Assert.That(result.Account.Value, Is.EqualTo("001548226815 EUR0BE"));
        Assert.That(result.Balance.Value, Is.EqualTo(-500012.100));
        Assert.That(result.Date.Value, Is.EqualTo(new DateTime(2015, 5, 12)));
    }
}