using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;

namespace Planning.ViewModel
{
    public class MessageAdmin
    {
        List<Message> Messages;

        public MessageAdmin() {
            Messages = new List<Message>();
        }

        public List<Message> GetAllMessages() {
            return Messages;
        }

        public void AddMessage(IChange change, string messagetext) {
            Message message;
            if (change is ITaskdescritpionChange)
                message = new TaskDescriptionMessage(change as ITaskdescritpionChange, messagetext);
            else
                message = new CitizenMessage(change as ICitizenChange, messagetext);

            Messages.Add(message);
            
        }
    }
}
