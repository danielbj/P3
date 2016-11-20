using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HifiPrototype2.Model
{
    class Group
    {
        List<Tuple<DateTime, Employee>> Template = new List<Tuple<DateTime, Employee>>();
        List<Tuple<DateTime, Employee>> Calender = new List<Tuple<DateTime, Employee>>();
    }
}
