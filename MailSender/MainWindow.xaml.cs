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
            DBclass db = new DBclass();
            dgEmails.ItemsSource = db.Emails;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MailSenderWindow msw = new MailSenderWindow();
            msw.Owner = this;
            msw.ShowDialog();
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
    }
}
