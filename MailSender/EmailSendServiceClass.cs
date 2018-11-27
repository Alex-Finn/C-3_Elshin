using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Collections.ObjectModel;

namespace WpfTestMailSender
{
    class EmailSendServiceClass
    {
        #region vars
        private string strLogin ; // email, c которого будет рассылаться почта
        private string strPassword ; // пароль к email, с которого будет рассылаться почта
        private string strSmtp = "smtp.mail.ru" ; // smtp - server
        private int iSmtpPort = 465 ; // порт для smtp-server
        private string strBody = "Hello world!"; // текст письма для отправки
        private string strSubject = "some subject..." ; // тема письма для отправки
        #endregion
        public EmailSendServiceClass (string sLogin , string sPassword)
        {
            strLogin = sLogin;
            strPassword = sPassword;
        }
        private void SendMail ( string mail , string name ) // Отправка email конкретному адресату
        {
            using (MailMessage mm = new MailMessage(strLogin, mail))
            {
                mm.Subject = strSubject;
                mm.Body = strBody;
                mm.IsBodyHtml = false;

                SmtpClient sc = new SmtpClient(strSmtp, iSmtpPort);
                sc.EnableSsl = true;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential(strLogin, strPassword);
                try
                {
                    sc.Send(mm);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                }
            }
        } //private void SendMail(string mail, string name)
        public void SendMails (ObservableCollection<Email> emails)
        {
            foreach (Email email in emails)
            {
                SendMail (email.Value, email.Name);
            }
        }
    }    //private void SendMail(string mail, string name)
    
    /*
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
    }*/
}