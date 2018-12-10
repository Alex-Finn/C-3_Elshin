using System.Windows.Controls;

namespace WpfTestMailSender.View
{
    /// <summary>
    /// Логика взаимодействия для SaveEmailView.xaml
    /// </summary>
    public partial class SaveEmailView : UserControl
    {
        public SaveEmailView()
        {
            InitializeComponent();
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            switch (e.Action)
            {
                case ValidationErrorEventAction.Added:
                    ((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
                    break;

                case ValidationErrorEventAction.Removed:
                    ((Control)sender).ToolTip = null;
                    break;
            }
        }
    }
}
