using System;
using System.Net;
using System.Windows;
using System.Net.Mail;
using System.Collections.Generic;
using System.Windows.Data;

namespace WpfTestMailSender
{
    /// <summary>
    /// Окно отправки сообщений
    /// </summary>
	partial class MailSenderWindow : Window
    {
        public MailSenderWindow()
        {
            InitializeComponent();
            //this.DataContext = SmtpClientsClass.letterSubject + SmtpClientsClass.letterBody;
        }

        void btnSendEmail_Click(object sender, RoutedEventArgs e)
	    {
            try
            {
                var send = new EmailSendServiceClass();
                send.Send(UserNameTextBox.Text, PasswordEdit.Password);
            }
            catch (Exception exception)
            {
                //MessageBox.Show(error.Message, "При отправке сообщения возникла ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                var dlg = new SendErrorWindow(exception.Message);
                dlg.ShowDialog();
            }
        }

    }
}