# **Payment**

## About
This class that represents a Payment

## **Properties**
---

Name | type | description | 
---|---|---
recipient| Recipient | The recipient of the payment
sourceAmount| double | The amount of the payment
memo| string | A memo for the payment
targetAmount| double | The amount that the recipient will receive
targetCurrency| string | Target currency code 3 letters ISO code
exchangeRate| double | The payment exchange rate
fees| double | The payment fees
recipientFees| double | Fees incurred by the recipient
fxRate| double | The fx rate of the payment
processedAt| string | The date that the payment was processed
createdAt| string |The date that the payment was created
updatedAt| string |The date that the payment was updated last
merchantFees| double | Fees incurred by the merchant
sourceCurrency|  string | Source currency code
batchId| string | The batch id (B-XXXXXXXXXXXXXXXX)
id| string | The payment id (P-XXXXXXXXXXXXXXXX)
status| string | The payment status
compliance| Compliance | The compliance information of the payment



 