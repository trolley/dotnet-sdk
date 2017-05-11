# **BankAccount**

## About
This class represents a merchant's balance. For more information see the [API documentation](http://docs.paymentrails.com/#balances)

## **Related Types**
---
+ [Address](Address.md)

## **Properties**
---

Name | Type | Description
---|---|---
Institution | string | The bank's institution number
BranchNum | string | The bank's branch number
AccountNum | string | The account's number
Routing | string | The accounts routing number
Iban | string | The bank's iban number
SwiftBic | string | The bank's SwiftBic number
GouvernmentID | string | The gouvernment id
Currency | string | The account's currency code
Name | string | The bank's name
Country | string | The bank's country code
BankAddress | Address | The bank's address


## **Methods**
---
Name | Return Type | Description
--- | --- | --- 
ToJson | string | Converts the object to a JSON string with all fields required for a POST or a Patch request.
IsMappable | Boolean | Determines weather the Object has the required fields to be POSTed to the API. This method throws an InvalidFieldException if the object is not valid.

