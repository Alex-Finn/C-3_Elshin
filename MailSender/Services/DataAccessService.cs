using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTestMailSender.Service;
using System.Data.Entity;
using Common;

namespace WpfTestMailSender.Services    
{
    public class DataAccessService : IDataAccessService
    {
        //EmailsDataContext context;
        EmailsModelContainer context;
        public DataAccessService()
        {
            //context = new EmailsDataContext();
            context = new EmailsModelContainer();
        }

        public int AddEmail(Common.Email email)
        {
            context.EmailSet.Add(email);
            context.SaveChanges();
            return email.Id;
        }

        public int DeleteEmail(Common.Email email)
        {
            if (context.Entry(email).State == EntityState.Detached )
            {
                context.EmailSet.Attach(email);
            }
            context.EmailSet.Remove(email);
            context.SaveChanges();
            return email.Id;
        }

        public int UpdateEmail(Common.Email email)
        {
            context.EmailSet.Attach(email);
            context.Entry(email).State = EntityState.Modified;
            context.SaveChanges();
            return email.Id;
        }

        public ObservableCollection<Common.Email> GetEmails()
        {
            ObservableCollection<Common.Email> Emails = new ObservableCollection<Common.Email>();
            //foreach (var item in context.Email)
            foreach (var item in context.EmailSet)
            {
                Emails.Add(item);
            }
            return Emails;
        }
    }
}