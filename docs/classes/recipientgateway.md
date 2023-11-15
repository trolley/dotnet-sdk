[Trolley C# SDK](../README.md) > [Trolley_Recipient_Gateway](../classes/Trolley_Recipient_Gateway.md)



# Class: Trolley_Recipient_Gateway

## Index

### Methods

* [create](Trolley_Recipient_Gateway.md#create)
* [find](Trolley_Recipient_Gateway.md#find)
* [remove](Trolley_Recipient_Gateway.md#remove)
* [search](Trolley_Recipient_Gateway.md#search)
* [update](Trolley_Recipient_Gateway.md#update)



---

## Methods
<a id="create"></a>

###  create

► **create**(body: *[Recipient](../types/recipient.md)*): `Recipient`



*Defined in [Trolley_Recipient_Gateway.cs:82](https://github.com/Trolley/dotnet-sdk/tree/master/trolley/Trolley_Recipient_Gateway.cs#L82)*



Create a given recipient

    Address address = new Address("123 Main St",null,null,null,null,"US",null);
    Recipient recipient = new Recipient(null,"individual",null,"tom.jones@example.com",null","Tom","Jones",null,null,null,null,null,null,null,address);

    recipient = client.recipient.create(recipient);

**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| body | [Recipient](../types/recipient.md)   |  The recipient information to create |



**Returns:** `Recipient`



___

<a id="find"></a>

###  find

► **find**(recipientId: *`string`*): `Recipient`
► **find**(recipient: *`Recipient`*): `Recipient`


*Defined in [Trolley_Recipient_Gateway.cs:58](https://github.com/Trolley/dotnet-sdk/tree/master/trolley/Trolley_Recipient_Gateway.cs#L58)*



Find a specific recipient by their Trolley recipient ID

    Recipient recipient = client.recipient.find('R-1234');


**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| recipientId | `string`   |  The Trolley recipient ID (e.g. R-xyzzy) |



**Returns:** `Recipient`





___

<a id="delete"></a>

###  delete

► **delete**(recipientId: *`string`*): `boolean`
► **delete**(recipient: *`Recipient`*): `boolean`



*Defined in [Trolley_Recipient_Gateway.cs:115](https://github.com/Trolley/dotnet-sdk/tree/master/trolley/Trolley_Recipient_Gateway.cs#L115)*



Delete the given recipient.

    bool status = client.recipient.delete('R-123');


**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| recipientId | `string`   |  The Trolley recipient ID (e.g. R-xyzzy) |
| recipient | `Recipient`   |  The Trolley recipient object |




**Returns:** `boolean`





___

<a id="search"></a>

###  search

► **search**(page: *`number`*, pageSize: *`number`*, term: *`string`*): `Recipient`[]



*Defined in [Trolley_Recipient_Gateway.cs:123](https://github.com/Trolley/dotnet-sdk/tree/master/trolley/Trolley_Recipient_Gateway.cs#L123)*



**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| page | `number`   |  - |
| pageSize | `number`   |  - |
| term | `string`   |  - |





**Returns:** `Recipient`[]





___

<a id="update"></a>

###  update

► **update**(body: *[Recipient](../types/recipient.md)*): `boolean`



*Defined in [Trolley_Recipient_Gateway.cs:100](https://github.com/Trolley/dotnet-sdk/tree/master/trolley/Trolley_Recipient_Gateway.cs#L100)*



Update the given recipient

    Recipient recipient = new Recipient(null, "individual", null, "tom.jones@example.com", null, "Tom", "Jones", null, null, null, "1990-04-29", null, null, null, null);
    recipient =  client.recipient.update(recipient);


**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| body | [Recipient](../types/recipient.md)   |  the changes to make to the recipient |





**Returns:** `boolean`





___


