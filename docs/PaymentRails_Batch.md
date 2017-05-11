# PaymentRails_Batch

## About
The PaymentRails_Batch class contains static utily methods for interfacing with the batch API. For more information see the [API documentation](http://docs.paymentrails.com/#payments)

## **Related Types**
---
+ [Batch](types/Batch.md)

## **Methods**
---
### **get**
Utility method to make GET requests to the batch API

Parameters | Return Type
--- | ---:
(int page, int pageSize) | List<Batch\>
(String batchId) | Batch

---
### **post**
Utility method to make POST requests to the batch API

Parameters | Return Type
--- | ---:
(Batch batch) | Batch

---
### **patch**
Utility method to make PATCH requests to the batch API

Parameters | Return Type
--- | ---:
(Batch batch) | String

---
### **delete**
Utility method to make DELETE requests to the batch API

Parameters | Return Type
--- | ---:
(Batch batch) | String
(String batchId) | String

---
### **query**
Utility method for querying batches

Parameters | Return Type
--- | ---:
(String term, int page, int pageSize) | List<Batch>

---
### **generateQuote**
Utility method to generating a quote for a bacth

Parameters | Return Type
--- | ---:
(String batchId) | String
(Batch batch) | String

---
### **processBatch**
Utility method to send a batch out for processing

Parameters | Return Type
--- | ---:
(String batchId) | String
(Batch batch) | String

---
### **summary**
Utility method to get a batch summary

Parameters | Return Type
--- | ---:
(String batchId) | String
(Batch batch) | String