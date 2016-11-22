using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Modules;

namespace Planning.Modules
{
    public class Task : Module, ITask
    {
        public Citizen Citizen { get; set; }
        public string assignment { get; set; }

        public Task(int startTime, string name) : base(startTime, name)
        {
        }

        public override string Duration
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int CalculateSize()
        {
            throw new NotImplementedException();
        }

        public override string Description()
        {
            throw new NotImplementedException();
        }

        //Impleement equals method
    }
}
