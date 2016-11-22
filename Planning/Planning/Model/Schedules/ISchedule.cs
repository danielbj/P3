using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Modules;

namespace Planning.Model.Schedules
{
    public interface ISchedule
    {
        string Name { get; }
        string Description { get; set; }
        bool Approved { get; }
        bool IsSaved { get; }
        //List<Module> _module { get; set; } private in class = unecessary in interface.
        void MoveModule();
        void AddModule(Module module);
        void DeleteElement(Module module);
        void DeleteSchedule();
        void Save();
        void Approve(bool state);
    }
}
