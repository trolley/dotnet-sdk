# **BankAccount**

## About
This class represents a merchant's balance. For more information see the [API documentation](http://docs.paymentrails.com/#balances)

## **Properties**
---

Name | Type | Description
---|---|---
Institution | String | The bank's institution number
BranchNum | String | The bank's branch number
AccountNum | String | The account's number
Routing | String | The accounts routing number
Iban | String | The bank's iban number
SwiftBic | String | The bank's SwiftBic number
GouvernmentID | String | The gouvernment id
Currency | String | The account's currency code
Name | String | The bank's name
Country | String | The bank's country code
BankAddress | Address | The bank's address


## **Methods**
---
Name | Return Type | Description
--- | --- | --- 
ToJson | String | Converts the object to a JSON string with all fields required for a POST or a Patch request.
IsMappable | Boolean | Determines weather the Object has the required fields to be POSTed to the API. This method throws an InvalidFieldException if the object is not valid.

