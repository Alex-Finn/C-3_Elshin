using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using WpfTestMailSender.Service;
using WpfTestMailSender.Services;
using Common;

namespace WpfTestMailSender.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        Common.Email _EmailInfo;
        public Common.Email EmailInfo
        {
            get { return _EmailInfo; }
            set
            {
                _EmailInfo = value;
                RaisePropertyChanged(nameof(EmailInfo));
            }
        }

        ObservableCollection<Common.Email> _Emails;

        public ObservableCollection<Common.Email> Emails
        {
            get { return _Emails; }
            set
            {
                _Emails = value;
                RaisePropertyChanged(nameof(Emails));
            }
        }

        IDataAccessService _serviceProxy;

        void GetEmails()
        {
            Emails.Clear();
            foreach (var item in _serviceProxy.GetEmails())
            {
                Emails.Add(item);
            }
        }

        void SaveEmail(Common.Email email)
        {
            EmailInfo.Id = _serviceProxy.AddEmail(email);
            if (EmailInfo.Id != 0)
            {
                Emails.Add(EmailInfo);
                RaisePropertyChanged(nameof(EmailInfo));
            }
        }

        public RelayCommand ReadAllCommand { get; set; }
        public RelayCommand<Common.Email> SaveCommand { get; set; }

        public MainWindowViewModel(IDataAccessService servProxy)
        {
            _serviceProxy = servProxy;
            Emails = new ObservableCollection<Common.Email>();
            EmailInfo = new Common.Email();
            ReadAllCommand = new RelayCommand(GetEmails);
            SaveCommand = new RelayCommand<Common.Email>(SaveEmail);
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 


        //public MainWindowViewModel()
        //{
        //    ////if (IsInDesignMode)
        //    ////{
        //    ////    // Code runs in Blend --> create design time data.
        //    ////}
        //    ////else
        //    ////{
        //    ////    // Code runs "for real"
        //    ////}
        //}
    }
}