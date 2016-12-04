using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;
using Planning.Model.Modules;

namespace Planning.Changes
{
    public abstract class CitizenChange<T> : Change<T, Citizen>
    {
        public CitizenChange(Citizen obj, T newValue, string desctription) : base(obj, newValue, desctription)
        {
        }
    }

    public class CitzenAddTaskChange : CitizenChange<TaskDescription>
    {
        public CitzenAddTaskChange(Citizen obj, TaskDescription newValue, string desctription) : base(obj, newValue, desctription)
        {
        }

        protected override void ApplyChange()
        {
            Obj.AddTask(NewValue);
        }
    }

    public class CitizenAddAddressChange : CitizenChange<Address>
    {
        public CitizenAddAddressChange(Citizen obj, Address newValue, string desctription) : base(obj, newValue, desctription)
        {
        }

        protected override void ApplyChange()
        {
            Obj.AddAddress(NewValue);
        }
    }

}
