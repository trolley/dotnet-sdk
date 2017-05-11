# **Address**

## About
This class represents a recipient's address. For more information see the [API documentation](http://docs.paymentrails.com/#recipient-attributes)

## **Properties**
---
Name | Type | Description
---|---|---
Street1|String|The recipient's street
Street2|String|The recipient's second street
City|String|The recipient's city
PostalCode|String|The recipient's postal code
Phone|String|The recipient's phone number
Country|String|The recipient's country code (ISO 3166-1 alpha-2)
Region|String|The recipient's region code (ISO 3166-2)

## **Methods**
---
Name | Return Type | Description
--- | --- | --- 
ToJson | String | Converts the object to a JSON string with all fields required for a POST or a Patch request.
IsMappable | Boolean | Determines weather the Object has the required fields to be POSTed to the API. This method throws an InvalidFieldException if the object is not valid.


