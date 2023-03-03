[Trolley C# SDK](../README.md) > [PaymentRails_Balances_Gateway](../classes/PaymentRails_Balances_Gateway.md)



# Class: PaymentRails_Balances_Gateway

## Index

### Methods

* [find](PaymentRails_Balances_Gateway.md#find)



---


## Methods

___

<a id="find"></a>

###  find

► **find**(kind: *"paypal"⎮"paymentrails"*): `Dictionary`<`String`, `Balance`>



*Defined in [PaymentRails_Balances_Gateway.ts:49](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/paymentrails/PaymentRails_Balances_Gateway.cs#L49)*



Fetch the account balance for the given account type

    Dictionary<String, Balance> balances = gateway.balances.find();


**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| kind | "paypal"⎮"paymentrails"   |  The account type to get the balances for |





**Returns:**  `Dictionary`<`String`, `Balance`>





___


