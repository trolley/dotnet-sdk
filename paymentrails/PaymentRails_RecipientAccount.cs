using PaymentRails.Types;
using System.Collections.Generic;

namespace PaymentRails
{
    public class PaymentRails_RecipientAccount
    {
        /// <summary>
        /// Retrieves a list of the recipient accounts for a given recipient
        /// </summary>
        /// <param name="recipient_id"></param>
        /// <returns></returns>
        public static List<RecipientAccount> findAll(string recipient_id)
        {
            return PaymentRails_Configuration.gateway().recipientAccount.findAll(recipient_id);
        }

        /// <summary>
        /// Retrives a recipient account based on the recipient id and recipient account id
        /// </summary>
        /// <param name="recipient_id"></param>
        /// <param name="recipient_account_id"></param>
        /// <returns></returns>
        public static RecipientAccount find(string recipient_id, string recipient_account_id)
        {
            return PaymentRails_Configuration.gateway().recipientAccount.find(recipient_id, recipient_account_id);
        }

        /// <summary>
        /// Creates a recipient account for the given recipient
        /// </summary>
        /// <param name="recipient_id"></param>
        /// <param name="recipientAccount"></param>
        /// <returns></returns>
        public static RecipientAccount create(string recipient_id, RecipientAccount recipientAccount)
        {
            return PaymentRails_Configuration.gateway().recipientAccount.create(recipient_id, recipientAccount);
        }

        /// <summary>
        /// Updates a recipient account for the given recipient
        /// </summary>
        /// <param name="recipient_id"></param>
        /// <param name="recipientAccount"></param>
        /// <returns></returns>
        public static RecipientAccount update(string recipient_id, RecipientAccount recipientAccount)
        {
            return PaymentRails_Configuration.gateway().recipientAccount.update(recipient_id, recipientAccount);
        }

        /// <summary>
        /// Deletes a recipient account for the given recipient
        /// </summary>
        /// <param name="recipient_id"></param>
        /// <param name="recipientAccount"></param>
        /// <returns></returns>
        public static bool delete(string recipient_id, RecipientAccount recipientAccount)
        {
            return delete(recipient_id, recipientAccount.id);
        }

        /// <summary>
        /// Deletes a recipient for the given recipient
        /// </summary>
        /// <param name="recipient_id"></param>
        /// <param name="recipient_account_id"></param>
        /// <returns></returns>
        public static bool delete(string recipient_id, string recipient_account_id)
        {
            return PaymentRails_Configuration.gateway().recipientAccount.delete(recipient_id, recipient_account_id);
        }
    }
}
