using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Common.Email
{
    public class Email
    {
        #region " Private/Internal properties "
        /// <summary>
        /// Gets sender information from EmailConfig object.
        /// </summary>
        private EmailConfig senderInfo;
        #endregion

        #region " Constructor/Destructor "
        /// <summary>
        /// Initializes a new instance of the Email class by using 
        /// the givin EmailConfig object.
        /// </summary>
        /// <param name="config">Preconfigured EmailConfig object</param>
        public Email(EmailConfig config)
        {
            this.senderInfo = config;
        }
        #endregion

        #region " Public functions "
        /// <summary>
        /// Sends email to the specified receiver.
        /// </summary>
        /// <param name="receiverEmail">The email of the receiver.</param>
        /// <param name="subject">Email subject.</param>
        /// <param name="htmlBody">Email body in HTML format.</param>
        public void Send(string receiverEmail, string subject, string htmlBody)
        {
            MailAddress receiver = new MailAddress(receiverEmail);

            using (MailMessage message =
                new MailMessage(this.senderInfo.Sender, receiver)
                {
                    Subject = subject,
                    Body = htmlBody,
                    IsBodyHtml = true
                })
            {
                this.senderInfo.GetSenderClient().Send(message);
            }
        }
        #endregion

    }
}
