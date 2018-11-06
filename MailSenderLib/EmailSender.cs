using System;
using System.Net;
using System.Net.Mail;

namespace MailSenderLib
{
    public class EmailSender
    {
        /// <summary>
        /// /// Метод отправляет письма
		/// </summary>
		/// <param name="strUser"></param>
		/// <param name="strPass"></param>
		/// <exception cref="SmtpException"></exception>
		public void Send(string strUser, string strPass)
	    {
			const string from = "user@yandex.ru";
		    const string to = "user@gmail.com";

		    const string server = "smtp.yandex.ru";

		    var user = strUser;
		    var pass = strPass;

		    try
		    {
                using (var message = new MailMessage(from, to, "Test message", "Test messae body"))
                {
                    message.IsBodyHtml = false; // Не используем html в теле письма

                    using (var client = new SmtpClient(server, 25))
                    {
                        client.EnableSsl = true;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(user, pass);
                        client.Send(message);
                    }                    
                }
		    }
		    catch (SmtpException error)
		    {
			   throw new SmtpException(error.Message);
		    }
		}
    }
}
