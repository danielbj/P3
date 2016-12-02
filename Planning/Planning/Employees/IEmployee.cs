using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Modules;



namespace Planning.Model.Employees
{
    public interface IEmployee
    {
        DateTime DateHired { get; set; }
        DateTime DateResigned { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
        int Qualification { get; set; }


        


    }
}
