# Trolley C# SDK

A native C# SDK for Trolley.

For more information about the API as well as C# code samples check out the [full API documentation](https://docs.trolley.com)

## Installation

#

#### For [C#](https://docs.microsoft.com/en-us/dotnet/articles/csharp/index)

#
### To install the reference: 
#### with dll  
In Solution Explorer, right-click the project node and click Add Reference. Select the dll in the file explorer and confirm your selection.

#### With NuGet
Open your package manager console and enter:  
`PM> Install-Package Trolley.SDK`


The library is hosted on github [here](https://github.com/Trolley/dotnet-sdk)

## Getting Started

### Namespaces
+ Trolley
+ Trolley.Types
+ Trolley.Exceptions

### Simple example

```csharp
// A simple c# application using the Trolley SDK
using Trolley;
using Trolley.Types;


class Program
{
    static void Main(string[] args)
    {
        // set your API key
	var client = new Trolley.Gateway("YOUR-API-KEY", "YOUR-SECRET-KEY");
        Recipient response = client.recipient.find("R-4q7zxMa26hpZhx7ULApBGw");
        Console.WriteLine(response.Id);
        
        Console.Read();
    }
}

```

### Usage

Methods should all have C# Doc comments to help you understand their usage. As mentioned the [full API documentation](https://docs.trolley.com)
is the best source of information about the API.

For more information please read the [C# API docs](https://github.com/Trolley/dotnet-sdk/tree/master/docs/) is available. The best starting point is:

| Data Type | SDK Documentation |
| ----- | ----- |
| Batch | [API Docs for Batch](https://github.com/Trolley/dotnet-sdk/tree/master/docs/classes/batchgateway.md) |
| Payment | [API Docs for Payment](https://github.com/Trolley/dotnet-sdk/tree/master/docs/classes/paymentgateway.md) |
| Recipient | [API Docs for Recipient](https://github.com/Trolley/dotnet-sdk/tree/master/docs/classes/recipientgateway.md) |
| Recipient Account | [API Docs for Recipient Account](https://github.com/Trolley/dotnet-sdk/tree/master/docs/classes/recipientaccountgateway.md) |

