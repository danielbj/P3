using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        #endregion

        public MailboxViewModel() {
            _messageAdmin = new MessageAdmin();
            Messages = _messageAdmin.GetAllMessages();
            SelectedMessage = Messages.First();

            AcceptChanges = new RelayCommand(p => AcceptChangeHandling(), p => SelectedMessage.IsRead);
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
