[Payment Rails C# SDK](../README.md) > [RecipientAccountGateway](../classes/recipientaccountgateway.md)



# Class: RecipientAccountGateway

## Index

### Methods

* [findAll](recipientaccountgateway.md#findAll)
* [create](recipientaccountgateway.md#create)
* [find](recipientaccountgateway.md#find)
* [remove](recipientaccountgateway.md#remove)
* [update](recipientaccountgateway.md#update)



---


## Methods
<a id="findAll"></a>

###  findAll

► **findAll**(recipientId: *`string`*): `List<RecipientAccount>`(recipientaccount.md)[]>



*Defined in [RecipientAccountGateway.ts:33](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/paymentrails/PaymentRails_RecipientAccountGateway.cs#L33)*



Fetch all of the accounts for a given Payment Rails recipient

    List<RecipientAccount> accounts = client.recipientAccount.findAll('R-1234');
*__throws__*: {NotFound} if recipient doesn't exist



**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| recipientId | `string`   |  The Payment Rails recipient ID (e.g. R-xyzzy) |





**Returns:** `List<RecipientAccount>(recipientaccount.md)[]>





___

<a id="create"></a>

###  create

► **create**(recipientId: *`string`*, body: *`RecipientAccount`*): `RecipientAccount`(recipientaccount.md)>



*Defined in [RecipientAccountGateway.ts:79](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/paymentrails/PaymentRails_RecipientAccountGateway.cs#L79)*



Create a new recipient account

    RecipientAccount recipientAccount = new RecipientAccount(null,null,"EUR",null,null,null,null,"FR","bank-transfer", "FR14 2004 1010 0505 0001 3M02 606", "123456",null,null,null,null,null,null,null,null,null);

    recipientAccount = client.recipientAccount.create("R-1234", recipientAccount);



**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| recipientId | `string`   |  The Payment Rails recipient ID (e.g. R-xyzzy) |
| body | `RecipientAccount`   |  Account information |





**Returns:** `RecipientAccount`(recipientaccount.md)>





___

<a id="find"></a>

###  find

► **find**(recipientId: *`string`*, accountId: *`string`*): `RecipientAccount`(recipientaccount.md)>



*Defined in [RecipientAccountGateway.ts:52](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/paymentrails/PaymentRails_RecipientAccountGateway.cs#L52)*



Fetch a specific account for a given Payment Rails recipient

    RecipientAccount account = client.recipientAccount.find('R-1234', 'A-789');
*__throws__*: {NotFound} if account or recipient don't exist



**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| recipientId | `string`   |  The Payment Rails recipient ID (e.g. R-xyzzy) |
| accountId | `string`   |  The Payment Rails account ID (e.g. A-xyzzy) |





**Returns:** `RecipientAccount`(recipientaccount.md)>





___

<a id="remove"></a>

###  remove

► **remove**(recipientId: *`string`*, accountId: *`string`*): `boolean`
► **remove**(recipientId: *`string`*, recipientAccount: *`RecipientAccount`*): `boolean`


*Defined in [RecipientAccountGateway.ts:121](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/paymentrails/PaymentRails_RecipientAccountGateway.cs#L121)*



Delete the given recipient account. This will only return success, otherwise it will throw an exception (e.g. NotFound)

    bool success = client.recipientAccount.remove('R-1234', 'A-789');


**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| recipientId | `string`   |  The Payment Rails recipient ID (e.g. R-xyzzy) |
| accountId | `string`   |  The Payment Rails account ID (e.g. A-xyzzy) |





**Returns:** `boolean`





___

<a id="update"></a>

###  update

► **update**(recipientId: *`string`*, accountId: *`string`*, body: *`RecipientAccount`*): `RecipientAccount`(recipientaccount.md)>



*Defined in [RecipientAccountGateway.ts:102](https://github.com/PaymentRails/paymentrails_dotnet/tree/master/paymentrails/PaymentRails_RecipientAccountGateway.cs#L102)*



Update a recipient account. Note: Updating an account will create a new account ID if it contains any property that isn't just "primary"

    RecipientAccount recipientAccount = new RecipientAccount(null,null,"EUR",null,null,null,null,"FR","bank-transfer", "FR14 2004 1010 0505 0001 3M02 606", "123456",null,null,null,null,null,null,null,null,null);

    const account = client.recipientAccount.update('R-1234', recipientAccount);


**Parameters:**

| Param | Type | Description |
| ------ | ------ | ------ |
| recipientId | `string`   |  The Payment Rails recipient ID (e.g. R-xyzzy) |
| accountId | `string`   |  The Payment Rails account ID (e.g. A-xyzzy) |
| body | `any`   |  Account information |





**Returns:** `RecipientAccount`(recipientaccount.md)>





___


