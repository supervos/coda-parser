using System;
using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers;

[TestFixture]
public class InitialStateLineParserTest
{
    [Test]
    public void TestAccountIsIbanIsSetCorrectly()
    {
        var parser = new InitialStateLineParser();

        var sample = "13155001548226815 EUR0BE                  0000000004004100241214CODELICIOUS               PROFESSIONAL ACCOUNT               255";

        Assert.That(parser.CanAcceptString(sample), Is.True);

        var result = (InitialStateLine)parser.Parse(sample);

        Assert.That(result.Account.Number.IsIbanNumber, Is.EqualTo(true));
    }

    [Test]
    public void TestSample1()
    {
        var parser = new InitialStateLineParser();

        var sample = "10155001548226815 EUR0BE                  0000000004004100241214CODELICIOUS               PROFESSIONAL ACCOUNT               255";

        Assert.That(parser.CanAcceptString(sample), Is.True);

        var result = (InitialStateLine)parser.Parse(sample);

        Assert.That(result.Account.NumberType.Value, Is.EqualTo("0"));
        Assert.That(result.StatementSequenceNumber.Value, Is.EqualTo(155));
        Assert.That(result.Account.Number.Value, Is.EqualTo("001548226815"));
        Assert.That(result.Account.Currency.CurrencyCode, Is.EqualTo("EUR"));
        Assert.That(result.Account.Country.CountryCode, Is.EqualTo("BE"));
        Assert.That(result.Account.Number.IsIbanNumber, Is.EqualTo(false));
        Assert.That(result.Balance.Value, Is.EqualTo(4004.100));
        Assert.That(result.Date.Value, Is.EqualTo(new DateTime(2014, 12, 24)));
        Assert.That(result.Account.Name.Value, Is.EqualTo("CODELICIOUS"));
        Assert.That(result.Account.Description.Value, Is.EqualTo("PROFESSIONAL ACCOUNT"));
        Assert.That(result.PaperStatementSequenceNumber.Value, Is.EqualTo(255));
    }
}