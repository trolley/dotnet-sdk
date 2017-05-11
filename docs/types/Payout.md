# **Payout**

## About
This class that represents a Payout

## **Properties**
---

Name | type | description | 
---|---|---
autoswitchLimit | double | The Payout auto switch limit
autoswitchActive | bool | The auto switch boolean
holdupLimit | double | The Payout hold up limit
holdupActive | bool | The hold up active boolean
primaryMethod | string | The payout primary method
primaryCurrency | string | The payout primary currency
bank | BankAccount | The Bank information
paypal | PaypalAccount | The Paypal information

## **Methods**
---
Name | Return Type | Description
--- | --- | --- 
ToJson | string | Converts the object to a JSON string with all fields required for a POST or a Patch request.
IsMappable | Boolean | Determines weather the Object has the required fields to be POSTed to the API. This method throws an InvalidFieldException if the object is not valid.
