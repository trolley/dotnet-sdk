# **Batch**

## About
This class that represents a Batch

## **Properties**
---

Name | type | description | 
---|---|---
description | string | A description of the batch
payments | List<Payment> | A list of all the payents in the batch
currency | double | The batch currency type
amount | double | The amount of money
totalPayments | int  | Amount of payments in the batch
status | string | The status of the batch (pending, active, accepted, complete)
sentAt | string | The date that the batch was send
completedAt | string | The date that the batch was completed
createdAt | string | The date that the batch was created
updatedAt | string | The date that the batch was last updated
id | string | The batch id (B-XXXXXXXXXXXXXXXX)

## **Methods**
---
Name | Return Type | Description
--- | --- | --- 
ToJson | string | Converts the object to a JSON string with all fields required for a POST or a Patch request.
IsMappable | Boolean | Determines weather the Object has the required fields to be POSTed to the API. This method throws an InvalidFieldException if the object is not valid.
