using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows;

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
            
            foreach (string mail in SmtpClientsClass.listStrMails)
            {
                // Используем using, чтобы гарантированно удалить объект MailMessage после использования
                try
                {
                    using (var message = new MailMessage(
                        from: SmtpClientsClass.fromAddress,
                        to: mail,
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
                            //try
                            //{
                                client.Send(message);
                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                            //}
                        }
                    }
                }
                catch (SmtpException error)
                {
                    throw new SmtpException(error.Message);
                }
                //MessageBox.Show("Работа завершена.");
                var okWindow = new SendOkWindow();
                okWindow.ShowDialog();
            }
        }
    }
}