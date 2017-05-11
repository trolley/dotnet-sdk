# PaymentRails_Recipient

## About
The PaymentRails_Recipient class contains static utily methods for interfacing with the recipient API. For more information see the [API documentation](http://docs.paymentrails.com/#recipients)

## **Methods**
---
### **get**
Utility method to make GET requests to the recipient API
Parameters | Return Type
<<<<<<< HEAD
---| ---:
=======
|---|---
>>>>>>> abcabb51a9a6ef0ad65dcd979cda4f2239aa2e9f
(int page, int pageSize) | List<Recipient\>
(String recipientId) | Recipient
(String recipientId, String term) | String

---
### **post**
Utility method to make POST requests to the recipient API
Parameters | Return Type
--- | ---:
(Recipient recipient) | Recipient

---
### **patch**
Utility method to make PATCH requests to the recipient API
Parameters | Return Type
--- | ---:
(Recipient recipient) | String

---
### **delete**
Utility method to make DELETE requests to the recipient API
Parameters | Return Type
--- | ---:
(Recipient recipient) | String
(String recipientId) | String

---
### **query**
Utility method for querying recipients
Parameters | Return Type
--- | ---:
(String term, int page, int pageSize) | List<Recipient>