using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodePasswordDLL;

namespace WpfTestMailSender
{
    public static class VariablesClass
    {
        public static Dictionary<string, string> Senders
        {
            get { return dicSenders; }
        }
        private static Dictionary<string, string> dicSenders = new Dictionary<string, string>()
        {            
            { "79257443993@yandex.ru" , CodePassword.getPassword ( "1234l;i" ) },
            { "sok74@yandex.ru" , CodePassword.getPassword ( ";liq34tjk" ) }
        };

        public static Dictionary<string, int> SmtpServers
        {
            get { return dicSmtp; }
        }
        private static Dictionary<string, int> dicSmtp = new Dictionary<string, int>()
        {
            { "smtp.mail.ru" , 465 },
            { "smtp.yandex.ru" , 465 },
            { "smtp.gmail.com" , 587 },
            { "smtp.mail.yahoo.com" , 465 }
        };
    }
}
