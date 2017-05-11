# **Recipient**

## About
This class that represents a Recipient

## **Properties**
---

Name | type | description | 
---|---|---
id|string| The recipient id (R-XXXXXXXXXXXXXXXX)
type|string| The type of recipient
referenceId|string| Recipient reference id
email|string |The recipient email address
name|string |The recipient full name, required for business
firstName|string|The recipient first name, required for individual	
lastName|string|The recipient last name, required for individual	
status|string| The recipient status
timeZone|string| The recipient time zone
language|string| The recipient language
dob| string| The recipient date of birth
gravatarUrl| string| Recipient gravatar url
Compliance |Compliance| The recipient compliance information
Payout| payout| The recipient payout methods
Address |address| The recipient address

## **Methods**
---
Name | Return Type | Description
--- | --- | --- 
ToJson | string | Converts the object to a JSON string with all fields required for a POST or a Patch request.
IsMappable | Boolean | Determines weather the Object has the required fields to be POSTed to the API. This method throws an InvalidFieldException if the object is not valid.
