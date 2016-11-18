using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Modules
{
    public class Task : Module
    {
        public Citizen _citizen;
        public string assignment;

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
    }
}
