using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfTestMailSender.ViewModel;

namespace WpfTestMailSender
{
    /// <summary>
    /// Главное окно программы
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            cbSenderSelect.ItemsSource = VariablesClass.Senders;
            cbSenderSelect.DisplayMemberPath = "Key";
            cbSenderSelect.SelectedValuePath = "Value";
            cbSenderSelect.SelectedIndex = 0;

            cbSmtpSelect.ItemsSource = VariablesClass.SmtpServers;
            cbSmtpSelect.DisplayMemberPath = "Key";
            cbSmtpSelect.SelectedValuePath = "Value";
            cbSmtpSelect.SelectedIndex = 0;
            //DBclass db = new DBclass();
            //dgEmails.ItemsSource = db.Emails;
        }               

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void miNew_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Нажата кнопка New\n" + e.Source.ToString());
        }

        private void miOpen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Нажата кнопка Open\n" + e.Source.ToString());
        }

        private void miLoad_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Нажата кнопка Load\n" + e.Source.ToString());
        }

        private void btnClock_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedItem = tabPlanner;
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSendAtOnce_Click(object sender, RoutedEventArgs e)
        {
            string strLogin = cbSenderSelect.Text;
            string strPassword = cbSenderSelect.SelectedValue.ToString();
            if (string.IsNullOrEmpty(strLogin))
            {
                MessageBox.Show("Выберите отправителя");
                return;
            }
            if (string.IsNullOrEmpty(strPassword))
            {
                MessageBox.Show("Укажите пароль отправителя");
                return;
            }
            EmailSendServiceClass emailSender = new EmailSendServiceClass(strLogin, strPassword);
            var locator = (ViewModelLocator)FindResource("Locator");
            emailSender.SendMails(locator.Main.Emails);
            
            //emailSender.SendMails((IQueryable<Email>)dgEmails.ItemsSource);
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SchedulerClass sc = new SchedulerClass();
            TimeSpan tsSendTime = sc.GetSendTime(tbTimePicker.Text);
            if (tsSendTime == new TimeSpan())
            {
                MessageBox.Show("Некорректный формат даты");
                return;
            }
            DateTime dtSendDateTime = (cldSchedulDateTimes.SelectedDate ?? DateTime.Today).Add(tsSendTime);
            if (dtSendDateTime < DateTime.Now)
            {
                MessageBox.Show("Дата и время отправки писем не могут быть раньше, чем настоящее время");
                return;
            }
            EmailSendServiceClass emailSender = new EmailSendServiceClass(cbSenderSelect.Text,
                cbSenderSelect.SelectedValue.ToString());
            var locator = (ViewModelLocator)FindResource("Locator");
            sc.SendEmails(dtSendDateTime, emailSender, locator.Main.Emails);            
            
            //sc.SendEmails(dtSendDateTime, emailSender, (IQueryable<Email>)dgEmails.ItemsSource);
        }
    }
}
