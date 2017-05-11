# **PaypalAccount**

## About
This class that represents a PaypalAccount

## **Properties**
---

Name | type | description | 
---|---|---
email | sting| The paypal Account email

## **Methods**
---
Name | Return Type | Description
--- | --- | --- 
ToJson | string | Converts the object to a JSON string with all fields required for a POST or a Patch request.
IsMappable | Boolean | Determines weather the Object has the required fields to be POSTed to the API. This method throws an InvalidFieldException if the object is not valid.
