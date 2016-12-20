using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Planning.Model;

namespace Planning.ViewModel
{
    public class MailboxViewModel : ViewModelBase
    {
        #region Events
        public delegate void UpdateListbox();
        public event UpdateListbox ChangeOfList;
        #endregion

        #region properties
        List<Message> _messages;
        public List<Message> Messages {
            get 
            {
                return _messages;
            }
            set 
            {
                _messages = value;
                OnPropertyChanged(nameof(Messages));
            }
        }
        Message _selectedMessage;
        public Message SelectedMessage {
            get { return _selectedMessage; }
            set {
                if (value == _selectedMessage || value == null)
                    return;
                _selectedMessage = value;
                _selectedMessage.SetToRead();
                OnPropertyChanged(nameof(SelectedMessage));
            }
        }

        public RelayCommand AcceptChanges { get; }

        #endregion

        #region Fields
        MessageAdmin _messageAdmin;
        GroupAdmin _groupAdmin;
        CitizenAdmin _citizenAdmin;
        #endregion

        public MailboxViewModel() {
            _messageAdmin = new MessageAdmin();
            _groupAdmin = GroupAdmin.Instance;
            _citizenAdmin = CitizenAdmin.Instance;
            MakeMessagesMockup();

            Messages = _messageAdmin.GetAllMessages();
            SelectedMessage = Messages.First();

            AcceptChanges = new RelayCommand(p => AcceptChangeHandling(), p => SelectedMessage.IsRead);
        }

        public void MakeMessagesMockup() {
            List<TaskDescription> tdList = new List<TaskDescription>();
            //List<EmployeeSchedule> empSchList;
            ITaskdescritpionChange change;
            //empSchList = _groupAdmin.GetAllGroups().FirstOrDefault().TemplateSchedules.FirstOrDefault().EmployeeSchedules.Take(4).ToList();

            //foreach (EmployeeSchedule empSch in empSchList) {
            //    empSch.TaskItems.Take(2).ToList().ForEach(t => tdList.Add(t.TaskDescription));
            //}

            foreach (var citizen in _citizenAdmin.GetCitizens())
            {
                citizen.Tasks.ForEach(td => tdList.Add(td));
            }

            foreach (TaskDescription td in tdList.Take(5).ToList()) {
                change = new TaskDurationChange(td, TimeSpan.FromMinutes(60), "Ændredede visiteret varighed");
                _messageAdmin.AddMessage(change, "Hej planlæggere, her er en ændring til varighed. God jul!");
                td.AddChange(change);
            }
        }

        private void AcceptChangeHandling() {
            try {
                Messages.Find(m => m == SelectedMessage).Change.Apply();
                Messages.Remove(SelectedMessage);
                SelectedMessage = Messages.FirstOrDefault();
            }
            catch (Exception) {
                MessageBox.Show("Alle opgaver er godkendte,", "Advarsel");
            }
            finally {
                OnPropertyChanged(nameof(Messages));
                OnPropertyChanged(nameof(SelectedMessage));
                ChangeOfList?.Invoke();
            }
        }







    }
}
