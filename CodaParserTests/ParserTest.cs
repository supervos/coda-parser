using System;
using System.Linq;
using CodaParser;
using NUnit.Framework;

namespace CodaParserTests
{
    [TestFixture]
    public class ParserTest
    {
        [Test]
        public void TestHas4EntriesWithStructuredMessage()
        {
            var parser = new Parser();
            var result = parser.ParseFile(GetSamplePath("sample1.cod"));

            Assert.That(result, Has.Count.EqualTo(1));
            var firstResult = result.First();
            Assert.AreEqual(17752.12, firstResult.InitialBalance);
            Assert.AreEqual(17832.12, firstResult.NewBalance);
            Assert.AreEqual(new DateTime(2017, 10, 11), firstResult.Date);
            Assert.IsEmpty(firstResult.InformationalMessage);

            Assert.That(firstResult.Transactions, Has.Count.EqualTo(4));
            var firstTransaction = firstResult.Transactions.First();
            Assert.AreEqual("GROTE WEG            32            3215    HASSELT", firstTransaction.Message);
            Assert.AreEqual("000003505158", firstTransaction.StructuredMessage);
            Assert.AreEqual(5, firstTransaction.Amount);
            Assert.AreEqual("KLANT1 MET NAAM1", firstTransaction.Account.Name);
            Assert.AreEqual("BE22313215646432", firstTransaction.Account.Number);
        }

        [Test]
        public void TestMessageOnMultipleLinesInformationBlock()
        {
            var parser = new Parser();
            var result = parser.ParseFile(GetSamplePath("sample4.cod"));

            Assert.AreEqual("Europese overschrijving (zie bijlage)  + 17.233,54Van: COMPANY BLABLABLAH BVBA - BE64NOT PR", result.First().Transactions.First().Message);
        }

        [Test]
        public void TestMessageOnMultipleLinesTransactionBlock()
        {
            var parser = new Parser();
            var result = parser.ParseFile(GetSamplePath("sample3.cod"));

            Assert.AreEqual("Message goes here and continues here or here", result.First().Transactions.First().Message);
        }

        [Test]
        public void TestNoAccount()
        {
            var parser = new Parser();
            var result = parser.ParseFile(GetSamplePath("sample2.cod"));

            Assert.IsEmpty(result.First().Transactions.First().Account.Name);
            Assert.AreEqual("Zichtrekening nr  21354598  - 2,11Justification in annex 00001680", result.First().Transactions.First().Message);
        }

        [Test]
        public void TestSample5SimpleFormat()
        {
            var parser = new Parser();
            var result = parser.ParseFile(GetSamplePath("sample5.cod"));

            Assert.That(result, Has.Count.EqualTo(1));
            var statement = result.First();
            Assert.AreNotEqual(default(DateTime), statement.Date);
            Assert.IsNotNull(statement.Account);
            Assert.AreNotEqual(default(decimal), statement.InitialBalance);
            Assert.AreNotEqual(default(decimal), statement.NewBalance);

            Assert.That(statement.Transactions, Has.Count.EqualTo(3));

            foreach (var transaction in statement.Transactions)
            {
                Assert.IsNotNull(transaction.Account);
                Assert.AreNotEqual(default(DateTime), transaction.TransactionDate);
                Assert.AreNotEqual(default(DateTime), transaction.ValutaDate);
                Assert.IsNotEmpty(transaction.Message);
                Assert.AreEqual("54875", transaction.ClientReference);
            }

            Assert.AreEqual(1, statement.Transactions[0].TransactionSequence);
            Assert.AreEqual(214, statement.Transactions[0].StatementSequence);

            Assert.AreEqual(2, statement.Transactions[1].TransactionSequence);
            Assert.AreEqual(214, statement.Transactions[1].StatementSequence);

            Assert.AreEqual(9, statement.Transactions[2].TransactionSequence);
            Assert.AreEqual(214, statement.Transactions[2].StatementSequence);
        }

        [Test]
        public void TestSample6()
        {
            var parser = new Parser();
            var result = parser.ParseFile(GetSamplePath("sample6.cod"));

            Assert.That(result, Has.Count.EqualTo(1));
            var statement = result.First();
            Assert.IsNotNull(statement.Account);
            Assert.That(statement.Transactions, Has.Count.EqualTo(3));
            Assert.AreEqual(new DateTime(2015, 1, 18), statement.Date);
            Assert.AreEqual(4004.1, statement.InitialBalance);
            Assert.AreEqual(-500012.1, statement.NewBalance);
            Assert.AreEqual("THIS IS A PUBLIC MESSAGE", statement.InformationalMessage);

            Assert.AreEqual("CODELICIOUS", statement.Account.Name);
            Assert.AreEqual("GEBABEBB", statement.Account.Bic);
            Assert.AreEqual("09029308273", statement.Account.CompanyIdentificationNumber);
            Assert.AreEqual("001548226815", statement.Account.Number);
            Assert.AreEqual("EUR", statement.Account.CurrencyCode);
            Assert.AreEqual("BE", statement.Account.CountryCode);

            var transaction1 = statement.Transactions[0];
            var transaction2 = statement.Transactions[1];
            var transaction3 = statement.Transactions[2];
            Assert.IsNotNull(transaction1.Account);
            Assert.AreEqual(new DateTime(2014, 12, 25), transaction1.TransactionDate);
            Assert.AreEqual(new DateTime(2014, 12, 25), transaction1.ValutaDate);
            Assert.AreEqual(-767.823, transaction1.Amount);
            Assert.AreEqual("112/4554/46812   813  ANOTHER MESSAGE  MESSAGE", transaction1.Message);
            Assert.IsEmpty(transaction1.StructuredMessage);

            Assert.AreEqual("BVBA.BAKKER PIET", transaction1.Account.Name);
            Assert.AreEqual("GEBCEEBB", transaction1.Account.Bic);
            Assert.AreEqual("BE54805480215856", transaction1.Account.Number);
            Assert.AreEqual("EUR", transaction1.Account.CurrencyCode);
            Assert.AreEqual(1, transaction1.TransactionSequence);
            Assert.AreEqual(214, transaction1.StatementSequence);

            Assert.AreEqual("54875", transaction2.Message);
            Assert.AreEqual("112455446812", transaction2.StructuredMessage);
            Assert.AreEqual(2, transaction2.TransactionSequence);
            Assert.AreEqual(214, transaction2.StatementSequence);

            Assert.IsEmpty(transaction3.Account.Name);
            Assert.AreEqual("GEBCEEBB", transaction3.Account.Bic);
            Assert.AreEqual(9, transaction3.TransactionSequence);
            Assert.AreEqual(214, transaction3.StatementSequence);
        }

        private string GetSamplePath(string sampleFile)
        {
            return System.IO.Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples", sampleFile);
        }
    }
}