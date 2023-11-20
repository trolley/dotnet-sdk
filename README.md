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
`PM> Install-Package trolleyhq`


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
        // set your API keys
	    var gateway = new Trolley.Gateway("<ACCESS_KEY>","<SECRET_KEY>");
        Recipient recipient = gateway.recipient.Get("R-a4q7zxMa26Zhx7ULApBGw");
        Console.WriteLine(recipient.Id);
        
        Console.Read();
    }
}

```

### Usage

Methods should all have C# Doc comments to help you understand their usage.

As mentioned the [full API documentation](https://docs.trolley.com) is the best source of information about the API.