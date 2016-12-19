using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class TaskItem : INotifyPropertyChanged
    {
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int TaskItemId { get; set; }

        public enum Status
        {
            Unplanned,
            Expired,
            Cancelled,
            Planned
        }

        private string _color = "LightSteelBlue";

        public string Color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged(nameof(Color));
                }
                
            }
        }



        public Status State { get; set; }

        private bool _locked;

        public bool Locked
        {
            get { return _locked; }
            set {
                if (_locked != value)
                {
                    _locked = value;
                    OnPropertyChanged(nameof(Locked));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RouteItem Route { get; set; }        
        public TimePeriod TimePeriod { get; set; }
        public TaskDescription TaskDescription { get; private set; }

        [Obsolete("Only needed for serialization and materialization in Entity Framework", true)]
        public TaskItem() { }

        public TaskItem(TaskDescription taskDescription)
        {
            TaskDescription = taskDescription;
            State = Status.Unplanned;
            Locked = false;
            TimePeriod = new TimePeriod(taskDescription.Duration);
            Route = new RouteItem();             
        }

        public override string ToString()
        {
            return TaskDescription.ToString(); 
        }

        public TaskItem Clone()
        {
            var clone = new TaskItem(this.TaskDescription);
            clone.TimePeriod.StartTime = TimeSpan.FromSeconds(this.TimePeriod.StartTime.TotalSeconds);
            clone.Route = this.Route;
            clone.Color = this.Color;
            clone.Locked = this.Locked;
            this.TaskDescription.TaskItems.Add(clone); // New
            return clone;
        }

    }
}
