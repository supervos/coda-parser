using System;
using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

namespace CodaParserTests.LineParsers;

[TestFixture]
public class TransactionPart1LineParserTest
{
    [Test]
    public void TestSample1()
    {
        var parser = new TransactionPart1LineParser();

        var sample = "21000100000001200002835        0000000001767820251214001120000112/4554/46812   813                                 25121421401 0";

        Assert.That(parser.CanAcceptString(sample), Is.True);

        var result = (TransactionPart1Line)parser.Parse(sample);
        Assert.That(result.SequenceNumber.Value, Is.EqualTo(1));
        Assert.That(result.SequenceNumberDetail.Value, Is.EqualTo(0));
        Assert.That(result.BankReference.Value, Is.EqualTo("0001200002835"));
        Assert.That(result.Amount.Value, Is.EqualTo(1767.820));
        Assert.That(result.ValutaDate.Value, Is.EqualTo(new DateTime(2014, 12, 25)));
        Assert.That(result.TransactionCode.Type.Value, Is.EqualTo("0"));
        Assert.That(result.TransactionCode.Family.Value, Is.EqualTo("01"));
        Assert.That(result.TransactionCode.Operation.Value, Is.EqualTo("12"));
        Assert.That(result.TransactionCode.Category.Value, Is.EqualTo("000"));
        Assert.That(result.MessageOrStructuredMessage.Message.Value, Is.EqualTo("112/4554/46812   813 "));
        Assert.That(result.MessageOrStructuredMessage.StructuredMessage, Is.Null);
        Assert.That(result.TransactionDate.Value, Is.EqualTo(new DateTime(2014, 12, 25)));
        Assert.That(result.StatementSequenceNumber.Value, Is.EqualTo(214));
        Assert.That(result.GlobalizationCode.Value, Is.EqualTo(0));
    }

    [Test]
    public void TestSampleWithStructuredMessage()
    {
        var parser = new TransactionPart1LineParser();

        var sample = "21000100000001200002835        0000000002767820251214001120001101112455446812  813                                 25121421401 0";

        Assert.That(parser.CanAcceptString(sample), Is.True);

        var result = (TransactionPart1Line)parser.Parse(sample);
        Assert.That(result.SequenceNumber.Value, Is.EqualTo(1));
        Assert.That(result.SequenceNumberDetail.Value, Is.EqualTo(0));
        Assert.That(result.BankReference.Value, Is.EqualTo("0001200002835"));
        Assert.That(result.Amount.Value, Is.EqualTo(2767.820));
        Assert.That(result.ValutaDate.Value, Is.EqualTo(new DateTime(2014, 12, 25)));
        Assert.That(result.TransactionCode.Type.Value, Is.EqualTo("0"));
        Assert.That(result.TransactionCode.Family.Value, Is.EqualTo("01"));
        Assert.That(result.TransactionCode.Operation.Value, Is.EqualTo("12"));
        Assert.That(result.TransactionCode.Category.Value, Is.EqualTo("000"));
        Assert.That(result.MessageOrStructuredMessage.Message, Is.Null);
        Assert.That(result.MessageOrStructuredMessage.StructuredMessage, Is.Not.Null);
        Assert.That(result.MessageOrStructuredMessage.StructuredMessage.StructuredMessageType, Is.EqualTo("101"));
        Assert.That(result.MessageOrStructuredMessage.StructuredMessage.StructuredMessageFull, Is.EqualTo("112455446812  813                                 "));
        Assert.That(result.MessageOrStructuredMessage.StructuredMessage.Value, Is.EqualTo("112455446812"));
        Assert.That(result.TransactionDate.Value, Is.EqualTo(new DateTime(2014, 12, 25)));
        Assert.That(result.StatementSequenceNumber.Value, Is.EqualTo(214));
        Assert.That(result.GlobalizationCode.Value, Is.EqualTo(0));
    }

    [Test]
    public void TestSepaDirectDebit()
    {
        var parser = new TransactionPart1LineParser();

        var sample = "2100280000VAAS00026BSDDXXXXXXXX1000000000050000050815005030001127050815112BEA123XXXXXXXXXXX                  M123  25121421401 0";

        Assert.That(parser.CanAcceptString(sample), Is.True);

        var result = (TransactionPart1Line)parser.Parse(sample);
        Assert.That(result.SequenceNumber.Value, Is.EqualTo(28));
        Assert.That(result.SequenceNumberDetail.Value, Is.EqualTo(0));
        Assert.That(result.BankReference.Value, Is.EqualTo("VAAS00026BSDDXXXXXXXX"));
        Assert.That(result.Amount.Value, Is.EqualTo(-50));
        Assert.That(result.ValutaDate.Value, Is.EqualTo(new DateTime(2015, 08, 05)));
        Assert.That(result.TransactionCode.Type.Value, Is.EqualTo("0"));
        Assert.That(result.TransactionCode.Family.Value, Is.EqualTo("05"));
        Assert.That(result.TransactionCode.Operation.Value, Is.EqualTo("03"));
        Assert.That(result.TransactionCode.Category.Value, Is.EqualTo("000"));
        Assert.That(result.MessageOrStructuredMessage.Message, Is.Null);
        Assert.That(result.MessageOrStructuredMessage.StructuredMessage, Is.Not.Null);
        Assert.That(result.MessageOrStructuredMessage.StructuredMessage.StructuredMessageType, Is.EqualTo("127"));
        Assert.That(result.MessageOrStructuredMessage.StructuredMessage.StructuredMessageFull, Is.EqualTo("050815112BEA123XXXXXXXXXXX                  M123  "));
        Assert.That(result.MessageOrStructuredMessage.StructuredMessage.Value, Is.Empty);
        Assert.That(result.TransactionDate.Value, Is.EqualTo(new DateTime(2014, 12, 25)));
        Assert.That(result.StatementSequenceNumber.Value, Is.EqualTo(214));
        Assert.That(result.GlobalizationCode.Value, Is.EqualTo(0));

        var sepaDirectDebit = result.MessageOrStructuredMessage.StructuredMessage.SepaDirectDebit;
        Assert.That(sepaDirectDebit, Is.Not.Null);
        Assert.That(sepaDirectDebit.SettlementDate.Value, Is.EqualTo(new DateTime(2015, 08, 05)));
        Assert.That(sepaDirectDebit.Type, Is.EqualTo(1));
        Assert.That(sepaDirectDebit.Scheme, Is.EqualTo(1));
        Assert.That(sepaDirectDebit.PaidReason, Is.EqualTo(2));
        Assert.That(sepaDirectDebit.CreditorIdentificationCode, Is.EqualTo("BEA123XXXXXXXXXXX"));
        Assert.That(sepaDirectDebit.MandateReference, Is.EqualTo("M123"));
    }
}