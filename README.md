# Payment Rails C# SDK

A native C# SDK for the Payment Rails API

For more information about the API as well as C# code samples check out the [full API documentation](http://docs.paymentrails.com)


## Installation

#

#### For [C#](https://docs.microsoft.com/en-us/dotnet/articles/csharp/index)

#
### To install the reference: 
#### with dll  
In Solution Explorer, right-click the project node and click Add Reference. Selec the dll in the file explorer and confirm your selection.

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
// A simple c# application using the Payment Rails SDK
using paymentrails.Types;
using paymentrails;

class Program
{
    static void Main(string[] args)
    {
        // set your API key
		var client = new PaymentRails_Gateway("YOUR-API-KEY", "YOUR-SECRET-KEY", "production");
        Recipient response = client.recipient.find("R-4q7zxMa26hpZhx7ULApBGw");
        Console.WriteLine(response.Id);
        
        Console.Read();
    }
}

```

### Usage

Methods should all have C# Doc comments to help you understand their usage. As mentioned the [full API documentation](http://docs.paymentrails.com)
is the best source of information about the API.

For more information please read the [C# API docs](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/docs/) is available. The best starting point is:

| Data Type | SDK Documentation |
| ----- | ----- |
| Batch | [API Docs for Batch](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/docs/classes/batchgateway.md) |
| Payment | [API Docs for Payment](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/docs/classes/paymentgateway.md) |
| Recipient | [API Docs for Recipient](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/docs/classes/recipientgateway.md) |
| Recipient Account | [API Docs for Recipient Account](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/docs/classes/recipientaccountgateway.md) |

