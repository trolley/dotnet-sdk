# Trolley C# SDK (Previously Payment Rails[^1])

A native C# SDK for Trolley.

For more information about the API as well as C# code samples check out the [full API documentation](https://docs.trolley.com)

[^1]: [Payment Rails is now Trolley](https://www.trolley.com/payment-rails-is-now-trolley-series-a). We're in the process of updating our SDKs to support the new domain. In this transition phase, you might still see "PaymentRails" at some places.

## Installation

#

#### For [C#](https://docs.microsoft.com/en-us/dotnet/articles/csharp/index)

#
### To install the reference: 
#### with dll  
In Solution Explorer, right-click the project node and click Add Reference. Select the dll in the file explorer and confirm your selection.

#### With NuGet
Open your package manager console and enter:  
`PM> Install-Package PaymentRails.SDK`


The library is hosted on github [here](https://github.com/PaymentRails/paymentrails_dotnet)

## Getting Started
### Namespaces
+ PaymentRails
+ PaymentRails.Types
+ PaymentRails.Exceptions
### Simple example

```csharp
// A simple c# application using the Trolley SDK
using PaymentRails;
using PaymentRails.Types;


class Program
{
    static void Main(string[] args)
    {
        // set your API key
	var client = new PaymentRails.Gateway("YOUR-API-KEY", "YOUR-SECRET-KEY");
        Recipient response = client.recipient.find("R-4q7zxMa26hpZhx7ULApBGw");
        Console.WriteLine(response.Id);
        
        Console.Read();
    }
}

```

### Usage

Methods should all have C# Doc comments to help you understand their usage. As mentioned the [full API documentation](https://docs.trolley.com)
is the best source of information about the API.

For more information please read the [C# API docs](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/docs/) is available. The best starting point is:

| Data Type | SDK Documentation |
| ----- | ----- |
| Batch | [API Docs for Batch](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/docs/classes/batchgateway.md) |
| Payment | [API Docs for Payment](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/docs/classes/paymentgateway.md) |
| Recipient | [API Docs for Recipient](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/docs/classes/recipientgateway.md) |
| Recipient Account | [API Docs for Recipient Account](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/docs/classes/recipientaccountgateway.md) |

