using System;
using System.Linq;
using CodaParser;
using NUnit.Framework;

namespace CodaParserTests;

[TestFixture]
public class ParserTest
{
    [Test]
    public void TestHas4EntriesWithStructuredMessage()
    {
        var parser = new Parser();
        var result = parser.ParseFile(GetSamplePath("sample1.cod")).ToList();

        Assert.That(result, Has.Count.EqualTo(1));
        var firstResult = result.First();
        Assert.That(firstResult.InitialBalance, Is.EqualTo(17752.12));
        Assert.That(firstResult.NewBalance, Is.EqualTo(17832.12));
        Assert.That(firstResult.Date, Is.EqualTo(new DateTime(2017, 10, 11)));
        Assert.That(firstResult.InformationalMessage, Is.Empty);

        Assert.That(firstResult.Transactions, Has.Count.EqualTo(4));
        var firstTransaction = firstResult.Transactions.First();
        Assert.That(firstTransaction.Message, Is.EqualTo("GROTE WEG            32            3215    HASSELT"));
        Assert.That(firstTransaction.StructuredMessage, Is.EqualTo("000003505158"));
        Assert.That(firstTransaction.Amount, Is.EqualTo(5));
        Assert.That(firstTransaction.Account.Name, Is.EqualTo("KLANT1 MET NAAM1"));
        Assert.That(firstTransaction.Account.Number, Is.EqualTo("BE22313215646432"));
    }

    [Test]
    public void TestMessageOnMultipleLinesInformationBlock()
    {
        var parser = new Parser();
        var result = parser.ParseFile(GetSamplePath("sample4.cod"));

        Assert.That(result.First().Transactions.First().Message, Is.EqualTo("Europese overschrijving (zie bijlage)  + 17.233,54Van: COMPANY BLABLABLAH BVBA - BE64NOT PR"));
    }

    [Test]
    public void TestMessageOnMultipleLinesTransactionBlock()
    {
        var parser = new Parser();
        var result = parser.ParseFile(GetSamplePath("sample3.cod"));

        Assert.That(result.First().Transactions.First().Message, Is.EqualTo("Message goes here and continues here or here"));
    }

    [Test]
    public void TestNoAccount()
    {
        var parser = new Parser();
        var result = parser.ParseFile(GetSamplePath("sample2.cod"));

        Assert.That(result.First().Transactions.First().Account.Name, Is.Empty);
        Assert.That(result.First().Transactions.First().Message, Is.EqualTo("Zichtrekening nr  21354598  - 2,11Justification in annex 00001680"));
    }

    [Test]
    public void TestSample5SimpleFormat()
    {
        var parser = new Parser();
        var result = parser.ParseFile(GetSamplePath("sample5.cod")).ToList();

        Assert.That(result, Has.Count.EqualTo(1));
        var statement = result.First();
        Assert.That(statement.Date, Is.Not.EqualTo(default(DateTime)));
        Assert.That(statement.Account, Is.Not.Null);
        Assert.That(statement.InitialBalance, Is.Not.EqualTo(default(decimal)));
        Assert.That(statement.NewBalance, Is.Not.EqualTo(default(decimal)));

        Assert.That(statement.Transactions, Has.Count.EqualTo(3));

        foreach (var transaction in statement.Transactions)
        {
            Assert.That(transaction.Account, Is.Not.Null);
            Assert.That(transaction.TransactionDate, Is.Not.EqualTo(default(DateTime)));
            Assert.That(transaction.ValutaDate, Is.Not.EqualTo(default(DateTime)));
            Assert.That(transaction.Message, Is.Not.Empty);
            Assert.That(transaction.ClientReference, Is.EqualTo("54875"));
        }

        Assert.That(statement.Transactions[0].TransactionSequence, Is.EqualTo(1));
        Assert.That(statement.Transactions[0].StatementSequence, Is.EqualTo(214));

        Assert.That(statement.Transactions[1].TransactionSequence, Is.EqualTo(2));
        Assert.That(statement.Transactions[1].StatementSequence, Is.EqualTo(214));

        Assert.That(statement.Transactions[2].TransactionSequence, Is.EqualTo(9));
        Assert.That(statement.Transactions[2].StatementSequence, Is.EqualTo(214));
    }

    [Test]
    public void TestSample6()
    {
        var parser = new Parser();
        var result = parser.ParseFile(GetSamplePath("sample6.cod")).ToList();

        Assert.That(result, Has.Count.EqualTo(1));
        var statement = result.First();
        Assert.That(statement.Account, Is.Not.Null);
        Assert.That(statement.Transactions, Has.Count.EqualTo(3));
        Assert.That(statement.Date, Is.EqualTo(new DateTime(2015, 1, 18)));
        Assert.That(statement.InitialBalance, Is.EqualTo(4004.1));
        Assert.That(statement.NewBalance, Is.EqualTo(-500012.1));
        Assert.That(statement.InformationalMessage, Is.EqualTo("THIS IS A PUBLIC MESSAGE"));

        Assert.That(statement.Account.Name, Is.EqualTo("CODELICIOUS"));
        Assert.That(statement.Account.Bic, Is.EqualTo("GEBABEBB"));
        Assert.That(statement.Account.CompanyIdentificationNumber, Is.EqualTo("09029308273"));
        Assert.That(statement.Account.Number, Is.EqualTo("001548226815"));
        Assert.That(statement.Account.CurrencyCode, Is.EqualTo("EUR"));
        Assert.That(statement.Account.CountryCode, Is.EqualTo("BE"));
        Assert.That(statement.Account.Description, Is.EqualTo("PROFESSIONAL ACCOUNT"));

        var transaction1 = statement.Transactions[0];
        var transaction2 = statement.Transactions[1];
        var transaction3 = statement.Transactions[2];
        Assert.That(transaction1.Account, Is.Not.Null);
        Assert.That(transaction1.TransactionDate, Is.EqualTo(new DateTime(2014, 12, 25)));
        Assert.That(transaction1.ValutaDate, Is.EqualTo(new DateTime(2014, 12, 25)));
        Assert.That(transaction1.Amount, Is.EqualTo(-767.823));
        Assert.That(transaction1.Message, Is.EqualTo("112/4554/46812   813  ANOTHER MESSAGE  MESSAGE"));
        Assert.That(transaction1.StructuredMessage, Is.Empty);

        Assert.That(transaction1.Account.Name, Is.EqualTo("BVBA.BAKKER PIET"));
        Assert.That(transaction1.Account.Bic, Is.EqualTo("GEBCEEBB"));
        Assert.That(transaction1.Account.Number, Is.EqualTo("BE54805480215856"));
        Assert.That(transaction1.Account.CurrencyCode, Is.EqualTo("EUR"));
        Assert.That(transaction1.TransactionSequence, Is.EqualTo(1));
        Assert.That(transaction1.StatementSequence, Is.EqualTo(214));

        Assert.That(transaction2.Message, Is.EqualTo("54875"));
        Assert.That(transaction2.StructuredMessage, Is.EqualTo("112455446812"));
        Assert.That(transaction2.TransactionSequence, Is.EqualTo(2));
        Assert.That(transaction2.StatementSequence, Is.EqualTo(214));

        Assert.That(transaction3.Account.Name, Is.Empty);
        Assert.That(transaction3.Account.Bic, Is.EqualTo("GEBCEEBB"));
        Assert.That(transaction3.TransactionSequence, Is.EqualTo(9));
        Assert.That(transaction3.StatementSequence, Is.EqualTo(214));
    }

    private string GetSamplePath(string sampleFile)
    {
        return System.IO.Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples", sampleFile);
    }
}