using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public interface IChange
    {
        DateTime DateCreated { get; }
        DateTime DateApplied { get; }
        string Description { get; }
        bool IsApplied { get; }

        void Apply();
    }

    public interface ITaskdescritpionChange : IChange
    {
        TaskDescription Obj { get; }
    }

    public interface ICitizenChange : IChange
    {
        Citizen Obj { get; }
    }
}
