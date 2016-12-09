using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public abstract class TaskDescriptionChange<T> : Change<T, TaskDescription> , ITaskdescritpionChange
    {
        public TaskDescriptionChange(TaskDescription obj, T newValue, string desctription) : base(obj, newValue, desctription)
        {
        }
    }

    public class TaskDurationChange : TaskDescriptionChange<TimeSpan>
    {
        public TaskDurationChange(TaskDescription obj, TimeSpan newValue, string desctription) : base(obj, newValue, desctription)
        {
        }

        protected override void ApplyChange()
        {
            Obj.Duration = NewValue;  // TODO
        }
    }

    public class TaskDescriptionstringChange : TaskDescriptionChange<string>
    {
        public TaskDescriptionstringChange(TaskDescription obj, string newValue, string desctription) : base(obj, newValue, desctription)
        {
        }

        protected override void ApplyChange()
        {
            Obj.Description = NewValue; // TODO
        }
    }
}
