using System.Linq;
using CodaParser;
using NUnit.Framework;

namespace CodaParserTests;

[TestFixture]
public class LinesParserTest
{
    [Test]
    public void TestSample1()
    {
        var parser = new LinesParser();

        var result = parser.ParseFile(GetSamplePath("sample5.cod")).ToList();
        Assert.That(result, Has.Count.EqualTo(16));
    }

    private string GetSamplePath(string sampleFile)
    {
        return System.IO.Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples", sampleFile);
    }
}