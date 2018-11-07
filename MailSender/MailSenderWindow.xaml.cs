using System;
using System.Net;
using System.Windows;
using System.Net.Mail;

namespace WpfTestMailSender
{
    /// <summary>
    /// Окно отправки сообщений
    /// </summary>
	partial class MailSenderWindow : Window
    {
		public MailSenderWindow() => InitializeComponent();
	    void Button_Click(object sender, RoutedEventArgs e)
	    {
		    try
		    {
			    var send = new EmailSendServiceClass();
			    send.Send(UserNameTextBox.Text, PasswordEdit.Password);
		    }
		    catch (Exception exception)
		    {
			    //MessageBox.Show(error.Message, "При отправке сообщения возникла ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			    var dlg = new MessageSendCompletedDlg(exception.Message);
			    dlg.ShowDialog();
		    }
	    }
	}
}