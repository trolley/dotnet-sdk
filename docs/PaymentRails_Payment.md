# PaymentRails_Payment

## About
The PaymentRails_Payment class contains static utily methods for interfacing with the payment API. For more information see the [API documentation](http://docs.paymentrails.com/#payments)

## **Methods**
---
### **get**
Utility method to make GET requests to the payment API
Parameters | Return Type
--- | ---:
`(int page, int pageSize)` | List<Payment\>
`(String paymentId)` | Payment

---
### **post**
Utility method to make POST requests to the payment API
Parameters | Return Type
--- | ---:
`(Payment payment)` | Payment

---
### **patch**
Utility method to make PATCH requests to the payment API
Parameters | Return Type
--- | ---:
`(Payment payment)` | String

---
### **delete**
Utility method to make DELETE requests to the payment API
Parameters | Return Type
--- | ---:
`(Payment payment)` | String
`(String paymentId)` | String

---
### **query**
Utility method for querying payments
Parameters | Return Type
--- | ---:
`(String term, int page, int pageSize)` | List<Payment>