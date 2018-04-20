Coda Parser
===========
C# .NET parser for Belgian CODA banking files.

This parser is a port of the [wimverstuyf/php-coda-parser](https://github.com/wimverstuyf/php-coda-parser).

Installation
------------
A NuGet package of this library will be released soon. In the mean time you can download the code and build it yourself.

The project is a .NET Standard 2.0 project and should work together with .NET Framework and .NET Core.

Usage
-----
```csharp
var parser = new Parser();
var statements = parser.ParseFile("coda-file.cod");

foreach (var statement in statements)
{
    Console.WriteLine(statement.Date.ToString("yyyy-MM-dd"));

    foreach (var transaction in statement.Transactions)
    {
        Console.WriteLine(transaction.Account.Name + ": " + transaction.Amount);
    }

    Console.WriteLine(statement.NewBalance);
}
```