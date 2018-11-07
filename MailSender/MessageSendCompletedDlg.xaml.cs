using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfTestMailSender
{
    /// <summary>
    /// Всплывающее окно с текстом ошибки
    /// </summary>
    public partial class MessageSendCompletedDlg : Window
    {
		
        public MessageSendCompletedDlg(string mess)
        {
            InitializeComponent();

	        textBox.Text = mess;
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (((Button) sender).Content.ToString() == "Ok")
                DialogResult = true;

            Close();
        }
    }
}
