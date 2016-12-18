using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public abstract class CitizenChange<T> : Change<T, Citizen>
    {
        public CitizenChange(Citizen obj, T newValue, string desctription) : base(obj, newValue, desctription)
        {
        }
    }

    public class CitizenAddTaskChange : CitizenChange<TaskDescription>
    {
        public CitizenAddTaskChange(Citizen obj, TaskDescription newValue, string desctription) : base(obj, newValue, desctription)
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
