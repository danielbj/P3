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
            Messages = DataBaseMockUp.LoadMessages();
        }

        public List<Message> GetAllMessages() {
            return Messages;
        }
    }
}
