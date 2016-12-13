using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;

namespace Planning.ViewModel
{
    class InboxViewModel
    {

        public List<Message> Messages;

        public InboxViewModel()
        {
            Messages = new List<Message>();
        }

        public void AddMessage(Message message)
        {
            Messages.Add(message);
            // Notify TODO
        }


    }
}
