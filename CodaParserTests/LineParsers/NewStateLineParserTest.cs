using System;
using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

[TestFixture]
public class NewStateLineParserTest
{
    [Test]
    public void TestSample1()
    {
        var parser = new NewStateLineParser();

        var sample = "8225001548226815 EUR0BE                  1000000500012100120515                                                                0";

        Assert.IsTrue(parser.CanAcceptString(sample));

        var result = (NewStateLine)parser.Parse(sample);

        Assert.AreEqual(225, result.StatementSequenceNumber.Value);
        Assert.AreEqual("001548226815 EUR0BE", result.Account.Value);
        Assert.AreEqual(-500012.100, result.Balance.Value);
        Assert.AreEqual(new DateTime(2015, 5, 12), result.Date.Value);
    }
}