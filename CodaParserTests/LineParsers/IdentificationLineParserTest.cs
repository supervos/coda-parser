using System;
using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers;

[TestFixture]
public class IdentificationLineParserTest
{
    [Test]
    public void TestSample1()
    {
        var parser = new IdentificationLineParser();

        var sample =
            "0000018011520105        0938409934CODELICIOUS               GEBABEBB   09029308273 00001          984309          834080       2";

        Assert.That(parser.CanAcceptString(sample), Is.True);

        var result = (IdentificationLine)parser.Parse(sample);

        Assert.Multiple(() =>
        {
            Assert.That(
                result.CreationDate.Value, 
                Is.EqualTo(new DateTime(2015, 01, 18)),
                nameof(result.CreationDate));
            Assert.That(
                result.BankIdentificationNumber.Value,
                Is.EqualTo("201"),
                nameof(result.BankIdentificationNumber));
            Assert.That(
                result.ApplicationCode.Value, 
                Is.EqualTo("05"), 
                nameof(result.ApplicationCode));
            Assert.That(
                result.IsDuplicate,
                Is.EqualTo(false),
                nameof(result.IsDuplicate));
            Assert.That(
                result.FileReference.Value,
                Is.EqualTo("0938409934"),
                nameof(result.FileReference));
            Assert.That(
                result.AccountName.Value,
                Is.EqualTo("CODELICIOUS"),
                nameof(result.AccountName));
            Assert.That(
                result.AccountBic.Value, 
                Is.EqualTo("GEBABEBB"), 
                nameof(result.AccountBic));
            Assert.That(
                result.AccountCompanyIdentificationNumber.Value,
                Is.EqualTo("09029308273"),
                nameof(result.AccountCompanyIdentificationNumber));
            Assert.That(
                result.ExternalApplicationCode.Value,
                Is.EqualTo("00001"),
                nameof(result.ExternalApplicationCode));
            Assert.That(
                result.TransactionReference.Value,
                Is.EqualTo("984309"),
                nameof(result.TransactionReference));
            Assert.That(
                result.RelatedReference.Value, 
                Is.EqualTo("834080"), 
                nameof(result.RelatedReference));
            Assert.That(
                result.VersionCode.Value,
                Is.EqualTo("2"),
                nameof(result.VersionCode));
        });
    }
}