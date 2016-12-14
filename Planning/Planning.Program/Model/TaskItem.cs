using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class TaskItem
    {
        public int TaskItemId { get; set; }

        public enum Status
        {
            Unplanned,
            Expired,
            Cancelled,
            Planned
        }

        public Status State { get; set; }
        public bool Locked;
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
            clone.Route.Duration = TimeSpan.FromSeconds(this.Route.Duration.TotalSeconds);
            return clone;
        }

    }
}
