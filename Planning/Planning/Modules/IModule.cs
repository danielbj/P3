using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model.Modules
{
    public interface IModule
    {

        int _startTime { get; set; }
        int _endTime { get; set; }
        string _name { get; set; }
        string Description { get; }

        string Duration { get; }
        int CalculateSize();
        


    }
}
