using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model.Modules
{
    public interface ITask
    {

        int _startTime { get; set; }
        int _endTime { get; set; }
        string _name { get; set; }
        Citizen Citizen { get; set; }
        string assignment { get; set; }
        string Duration { get; }
        int CalculateSize();
        string Description();


    }
}
