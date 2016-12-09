using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public abstract class Change<T, U> : IChange
    {
        public DateTime DateCreated { get; }
        public DateTime DateApplied { get; private set; }
        public bool IsApplied{ get; private set; } = false;

        public U Obj { get; protected set; }
        public T NewValue { get; protected set; }
        public string Description { get; }

        public Change(U obj, T newValue, string desctription)
        {
            Obj = obj;
            NewValue = newValue;
            DateCreated = DateTime.Now;
            Description = desctription;
        }

        protected abstract void ApplyChange();

        public void Apply()
        {
            ApplyChange();
            DateApplied = DateTime.Now;
            IsApplied = true;
        }

        public override string ToString()
        {
            return DateApplied.ToString() + " - " + Obj.ToString() + ": " + Description + " : New Value: " + NewValue.ToString();
        }
    }
}
