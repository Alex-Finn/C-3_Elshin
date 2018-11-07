using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace WpfTestMailSender
{
    /// <summary>
    /// Класс с описанием логики отправления писем
    /// </summary>
    class EmailSendServiceClass
    {
        /// <summary>
        /// /// Метод отправляет письма
        /// </summary>
        /// <param name="strUser">Логин пользователя</param>
        /// <param name="strPass">Пароль пользователя</param>
        /// <exception cref="SmtpException"></exception>
        public void Send(string strUser, string strPass)
        {
            var user = strUser;
            var pass = strPass;

            try
            {
                using (var message = new MailMessage(
                    from: SmtpClientsClass.fromAddress,
                    to: SmtpClientsClass.toAddress,
                    subject: SmtpClientsClass.letterSubject,
                    body: SmtpClientsClass.letterBody))
                {
                    message.IsBodyHtml = false; // Не используем html в теле письма

                    using (var client = new SmtpClient(
                        host: SmtpClientsClass.yandexRuServer,
                        port: SmtpClientsClass.yandexRuPort))
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
