using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Planning.Model
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
