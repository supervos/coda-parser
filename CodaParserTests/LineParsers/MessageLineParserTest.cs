using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers;

[TestFixture]
public class MessageLineParserTest
{
    [Test]
    public void TestSample1()
    {
        var parser = new MessageLineParser();

        var sample = "4 00010005                      THIS IS A PUBLIC MESSAGE                                                                       0";

        Assert.That(parser.CanAcceptString(sample), Is.True);

        var result = (MessageLine)parser.Parse(sample);

        Assert.That(result.SequenceNumber.Value, Is.EqualTo(1));
        Assert.That(result.SequenceNumberDetail.Value, Is.EqualTo(5));
        Assert.That(result.Content.Value, Is.EqualTo("THIS IS A PUBLIC MESSAGE "));
    }

    [Test]
    public void TestSample2()
    {
        var parser = new MessageLineParser();

        var sample = "4 00020000                                              ACCOUNT INFORMATION                                                    1";

        Assert.That(parser.CanAcceptString(sample), Is.True);

        var result = (MessageLine)parser.Parse(sample);

        Assert.That(result.SequenceNumber.Value, Is.EqualTo(2));
        Assert.That(result.SequenceNumberDetail.Value, Is.EqualTo(0));
        Assert.That(result.Content.Value, Is.EqualTo(" ACCOUNT INFORMATION "));
    }
}