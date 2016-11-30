using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Employees;
using Planning.Model.Modules;

namespace Planning.ViewModel
{
    class CitizenViewModel
    {
        IModule Task; 
        public CitizenViewModel(IModule task) {
            Task = task;
        }
    }
}
