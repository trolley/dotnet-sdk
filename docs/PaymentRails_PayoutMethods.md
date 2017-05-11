# PaymentRails_PayoutMethods

## **About**
The PaymentRails_PayoutMethods class contains static utily methods for interfacing with the payout methods API. For more information see the [API documentation](http://docs.paymentrails.com/#payout-methods)

## **Methods**
---
### **get**
Utility method to make GET requests to the payout method API
Parameters | Return Type
--- | :---
(String recipientId) | Payout

---
### **post**
Utility method to make POST requests to the payout method API
Parameters | Return Type
--- | :---
(String recipientId, Payout payoutMethod) | Payout

---
### **patch**
Utility method to make PATCH requests to the payout method API
Parameters | Return Type
--- | :---
(String recipientId, Payout payoutMethod) | String

