using System;
using CodaParser.LineParsers;
using CodaParser.Lines;
using NUnit.Framework;

[TestFixture]
internal class TransactionPart1LineParserTest
{
    [Test]
    public void TestSample1()
    {
        var parser = new TransactionPart1LineParser();

        var sample = "21000100000001200002835        0000000001767820251214001120000112/4554/46812   813                                 25121421401 0";

        Assert.IsTrue(parser.CanAcceptString(sample));

        var result = (TransactionPart1Line)parser.Parse(sample);
        Assert.AreEqual(1, result.SequenceNumber.Value);
        Assert.AreEqual(0, result.SequenceNumberDetail.Value);
        Assert.AreEqual("0001200002835", result.BankReference.Value);
        Assert.AreEqual(1767.820, result.Amount.Value);
        Assert.AreEqual(new DateTime(2014, 12, 25), result.ValutaDate.Value);
        Assert.AreEqual("0", result.TransactionCode.Type.Value);
        Assert.AreEqual("01", result.TransactionCode.Family.Value);
        Assert.AreEqual("12", result.TransactionCode.Operation.Value);
        Assert.AreEqual("000", result.TransactionCode.Category.Value);
        Assert.AreEqual("112/4554/46812   813 ", result.MessageOrStructuredMessage.Message.Value);
        Assert.IsNull(result.MessageOrStructuredMessage.StructuredMessage);
        Assert.AreEqual(new DateTime(2014, 12, 25), result.TransactionDate.Value);
        Assert.AreEqual(214, result.StatementSequenceNumber.Value);
        Assert.AreEqual(0, result.GlobalizationCode.Value);
    }

    [Test]
    public void TestSampleWithStructuredMessage()
    {
        var parser = new TransactionPart1LineParser();

        var sample = "21000100000001200002835        0000000002767820251214001120001101112455446812  813                                 25121421401 0";

        Assert.IsTrue(parser.CanAcceptString(sample));

        var result = (TransactionPart1Line)parser.Parse(sample);
        Assert.AreEqual(1, result.SequenceNumber.Value);
        Assert.AreEqual(0, result.SequenceNumberDetail.Value);
        Assert.AreEqual("0001200002835", result.BankReference.Value);
        Assert.AreEqual(2767.820, result.Amount.Value);
        Assert.AreEqual(new DateTime(2014, 12, 25), result.ValutaDate.Value);
        Assert.AreEqual("0", result.TransactionCode.Type.Value);
        Assert.AreEqual("01", result.TransactionCode.Family.Value);
        Assert.AreEqual("12", result.TransactionCode.Operation.Value);
        Assert.AreEqual("000", result.TransactionCode.Category.Value);
        Assert.IsNull(result.MessageOrStructuredMessage.Message);
        Assert.IsNotNull(result.MessageOrStructuredMessage.StructuredMessage);
        Assert.AreEqual("101", result.MessageOrStructuredMessage.StructuredMessage.StructuredMessageType);
        Assert.AreEqual("112455446812  813                                 ", result.MessageOrStructuredMessage.StructuredMessage.StructuredMessageFull);
        Assert.AreEqual("112455446812", result.MessageOrStructuredMessage.StructuredMessage.Value);
        Assert.AreEqual(new DateTime(2014, 12, 25), result.TransactionDate.Value);
        Assert.AreEqual(214, result.StatementSequenceNumber.Value);
        Assert.AreEqual(0, result.GlobalizationCode.Value);
    }

    [Test]
    public void TestSepaDirectDebit()
    {
        var parser = new TransactionPart1LineParser();

        var sample = "2100280000VAAS00026BSDDXXXXXXXX1000000000050000050815005030001127050815112BEA123XXXXXXXXXXX                  M123  25121421401 0";

        Assert.IsTrue(parser.CanAcceptString(sample));

        var result = (TransactionPart1Line)parser.Parse(sample);
        Assert.AreEqual(28, result.SequenceNumber.Value);
        Assert.AreEqual(0, result.SequenceNumberDetail.Value);
        Assert.AreEqual("VAAS00026BSDDXXXXXXXX", result.BankReference.Value);
        Assert.AreEqual(-50, result.Amount.Value);
        Assert.AreEqual(new DateTime(2015, 08, 05), result.ValutaDate.Value);
        Assert.AreEqual("0", result.TransactionCode.Type.Value);
        Assert.AreEqual("05", result.TransactionCode.Family.Value);
        Assert.AreEqual("03", result.TransactionCode.Operation.Value);
        Assert.AreEqual("000", result.TransactionCode.Category.Value);
        Assert.IsNull(result.MessageOrStructuredMessage.Message);
        Assert.IsNotNull(result.MessageOrStructuredMessage.StructuredMessage);
        Assert.AreEqual("127", result.MessageOrStructuredMessage.StructuredMessage.StructuredMessageType);
        Assert.AreEqual("050815112BEA123XXXXXXXXXXX                  M123  ", result.MessageOrStructuredMessage.StructuredMessage.StructuredMessageFull);
        Assert.IsEmpty(result.MessageOrStructuredMessage.StructuredMessage.Value);
        Assert.AreEqual(new DateTime(2014, 12, 25), result.TransactionDate.Value);
        Assert.AreEqual(214, result.StatementSequenceNumber.Value);
        Assert.AreEqual(0, result.GlobalizationCode.Value);

        var sepaDirectDebit = result.MessageOrStructuredMessage.StructuredMessage.SepaDirectDebit;
        Assert.IsNotNull(sepaDirectDebit);
        Assert.AreEqual(new DateTime(2015, 08, 05), sepaDirectDebit.SettlementDate.Value);
        Assert.AreEqual(1, sepaDirectDebit.Type);
        Assert.AreEqual(1, sepaDirectDebit.Scheme);
        Assert.AreEqual(2, sepaDirectDebit.PaidReason);
        Assert.AreEqual("BEA123XXXXXXXXXXX", sepaDirectDebit.CreditorIdentificationCode);
        Assert.AreEqual("M123", sepaDirectDebit.MandateReference);
    }
}