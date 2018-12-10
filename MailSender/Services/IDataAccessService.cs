using System.Collections.ObjectModel;

namespace WpfTestMailSender.Service
{
    public interface IDataAccessService
    {
        ObservableCollection<Common.Email> GetEmails();
        int AddEmail(Common.Email email);
        int UpdateEmail(Common.Email email);
        int DeleteEmail(Common.Email email);
    }
}