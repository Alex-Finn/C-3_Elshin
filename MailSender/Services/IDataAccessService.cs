using System.Collections.ObjectModel;

namespace WpfTestMailSender.Service
{
    public interface IDataAccessService
    {
        ObservableCollection<Email> GetEmails();
        int CreateEmail(Email email);
    }
}