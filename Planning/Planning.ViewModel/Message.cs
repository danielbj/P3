using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;
using Planning.Changes;

namespace Planning.ViewModel
{
    public abstract class Message
    {
        public string Title { get; }
        public string Content { get; }
        public DateTime Date { get; }
        public IChange Change { get; protected set; }
        public bool IsRead { get; private set; } = false;


        public Message(string title, string content)
        {
            Title = title;
            Content = content;
            Date = DateTime.Now;
        }

        public void SetToRead()
        {
            IsRead = true;
        }

        public override string ToString()
        {
            return Date.ToShortDateString() + " - " + Title;
        }
    }

    public class TaskDescriptionMessage : Message
    {
        public TaskDescriptionMessage(ITaskdescritpionChange change, string content) : base(change.Obj.Citizen.ToString(), content)
        {
            Change = change;
        }
    }

    public class CitizenMessage : Message
    {
        public CitizenMessage(ICitizenChange change, string content) : base(change.Obj.ToString(), content)
        {
            Change = change;
        }
    }

}
