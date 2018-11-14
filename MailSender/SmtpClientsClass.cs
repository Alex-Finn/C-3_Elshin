using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestMailSender
{
    /// <summary>
    /// Класс содержит статические члены с адресами серверов почты, портов, адресов отправителя и получателя,
    /// а также с текстом и темой письма
    /// </summary>
    public static class SmtpClientsClass
    {
        static public List<string> listStrMails = new List<string>
            {
                "testEmail@gmail.com",
                "email@yandex.ru",
                "user@gmail.com"
            };  // Список email'ов кому мы отправляем письмо
        public static string yandexRuServer = "smtp.yandex.ru";
        public static string gmailComServer = "smtp.gmail.com";
        public static string mailRuServer = "smtp.mail.ru";
        public static int yandexRuPort = 25;
        public static int gmailComPort = 58;
        public static int mailRuPort = 25;
        public static string fromAddress = "user@yandex.ru";
        public static string toAddress = "user@gmail.com";
        public static string letterSubject = "Some subject...";
        public static string letterBody = "Some letter body...";
    }
}
