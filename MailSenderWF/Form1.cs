using System;
using System.Windows.Forms;
using MailSender;
using MailSenderLib;

namespace MailSenderWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
		}

        private void button1_Click(object sender, EventArgs e)
        {
	        try
	        {
		        var send = new EmailSender();
		        send.Send(textBox1.Text, textBox1.Text);
	        }
	        catch (Exception exception)
	        {
		        MessageBox.Show(exception.Message, "При отправке сообщения возникла ошибка");
		    }
		}
    }
}
