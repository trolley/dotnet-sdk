[Trolley C# SDK](../README.md) > [PaymentRails_Batch_Gateway](../classes/PaymentRails_Batch_Gateway.md)



# Class: PaymentRails_Batch_Gateway


Gateway class for batches
*__class__*: PaymentRails_Batch_Gateway


## Index

### Methods

* [create](PaymentRails_Batch_Gateway.md#create)
* [find](PaymentRails_Batch_Gateway.md#find)
* [generateQuote](PaymentRails_Batch_Gateway.md#generatequote)
* [paymentList](PaymentRails_Batch_Gateway.md#paymentlist)
* [delete](PaymentRails_Batch_Gateway.md#delete)
* [search](PaymentRails_Batch_Gateway.md#search)
* [processBatch](PaymentRails_Batch_Gateway.md#processBatch)
* [summary](PaymentRails_Batch_Gateway.md#summary)
* [update](PaymentRails_Batch_Gateway.md#update)



---
## Methods
<a id="create"></a>

###  create

► **create**(batch: *`Batch`*): `Batch`



*Defined in [PaymentRails_Batch_Gateway.cs:95](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/paymentrails/PaymentRails_Batch_Gateway.cs#L95)*



Creates a batch with optional payments. This is the interface that is provide by the [Create Batch](https://docs.trolley.com/api/#create-a-batch) API

    Address address = new Address("123 Wolfstrasse", null, "Berlin", "123123", null, "DE", null);
    
    Recipient recipient = new Recipient(null, "individual", null, "tom.jones@example.com", null, "Tom", "Jones", null, null, null, "1990-01-01", null, null, null, address);
           
    Payment paymentAlpha = new Payment(recipientAlpha,0,null,10.00,"EUR",0,0,0,0,null,null,null,0,null,null,null,null,null);
    List<Payment> payments = new List<Payment>();
    payments.Add(paymentAlpha);

    Batch batch = new Batch("My Batch",payments,"USD",10.20,0,null,null,null,null,null,null);
    batch = gateway.batch.create(batch);


**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| batch | `Batch`   |  - |





**Returns:** `Batch`





___

<a id="find"></a>

###  find

► **find**(batchId: *`string`*): `Batch`



*Defined in [PaymentRails_Batch_Gateway.cs:67](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/paymentrails/PaymentRails_Batch_Gateway.cs#L67)*



Retrieves a batch based on the batch id

    Batch batch = client.batch.find('B-xx999bb');


**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| batchId | `string`   |  Trolley batch id (e.g. "B-xx999bb") |





**Returns:** `Batch`





___

<a id="generatequote"></a>

###  generateQuote

► **generateQuote**(batchId: *`string`*): `Batch`



*Defined in [PaymentRails_Batch_Gateway.cs:182](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/paymentrails/PaymentRails_Batch_Gateway.cs#L182)*



Generate a FX quote for this batch


**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| batchId | `string`   |  Trolley payment id (e.g. "B-xx999bb") |





**Returns:** `Batch`





___

<a id="paymentlist"></a>

###  paymentList

► **paymentList**(batchId: *`string`*, page?: *`number`*, pageSize?: *`number`*): `Promise`.<`Payment`[]>



*Defined in [PaymentRails_Batch_Gateway.cs:166](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/paymentrails/PaymentRails_Batch_Gateway.cs#L166)*



Return a paginated list of payments for this batch


**Parameters:**

| Param | Type | Default value | Description |
| ------ | ------ | ------ | ------ |
| batchId | `string`  | - |   Trolley payment id (e.g. "B-xx999bb") |
| page | `number`  | 1 |   starting a 1 |
| pageSize | `number`  | 10 |   in the range 0...1000 |





**Returns:** `Promise`.<`Payment`[]>





___

<a id="delete"></a>

###  delete

► **delete**(batchId: *`string`*): `Boolean`
► **delete**(batch: *`Batch`*): `Boolean`


*Defined in [PaymentRails_Batch_Gateway.cs:132](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/paymentrails/PaymentRails_Batch_Gateway.cs#L132)*



Delete the given batch

    boolean success = client.batch.delete('B-xx999bb');


**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| batchId | `string`   |  Trolley batch (e.g. "B-xx999bb") |
| batch | `Batch`   |  Trolley batch |




**Returns:** `Boolean`





___

<a id="search"></a>

###  search

► **search**(page?: *`number`*, pageSize?: *`number`*, term?: *`string`*): `Batch`[]



*Defined in [PaymentRails_Batch_Gateway.cs:146](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/paymentrails/PaymentRails_Batch_Gateway.cs#L146)*



Search for a batch matching the given term


**Parameters:**

| Param | Type | Default value | Description |
| ------ | ------ | ------ | ------ |
| page | `number`  | 1 |   - |
| pageSize | `number`  | 10 |   - |
| term | `string`  | &quot;&quot; |   string search term |





**Returns:** `Batch`[]





___

<a id="processBatch"></a>

###  processBatch

► **processBatch**(batchId: *`string`*): `Batch`



*Defined in [PaymentRails_Batch_Gateway.cs:194](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/paymentrails/PaymentRails_Batch_Gateway.cs#L194)*



Start processing this batch


**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| batchId | `string`   |  Trolley batch id (e.g. "B-xx999bb") |





**Returns:** `Batch`





___

<a id="summary"></a>

###  summary

► **summary**(batchId: *`string`*): `String`



*Defined in [PaymentRails_Batch_Gateway.cs:206](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/paymentrails/PaymentRails_Batch_Gateway.cs#L206)*



Get a transaction totaled summary for this batch


**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| batchId | `string`   |  Trolley payment id (e.g. "B-xx999bb") |





**Returns:** `String`





___

<a id="update"></a>

###  update

► **update**(batch: *`Batch`*): `boolean`



*Defined in [PaymentRails_Batch_Gateway.cs:117](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/paymentrails/PaymentRails_Batch_Gateway.cs#L117)*



Update the batch data, note you can only update the information of a batch not the payments via this API

    Batch batch = new Batch("My Batch for Wednesday", null, "USD", 0, 0, null, null, null, null, null, null);
    batch = client.batch.create(batch);


**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| body | `Batch`   |  - |





**Returns:** `boolean`





___


