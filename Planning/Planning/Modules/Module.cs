using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Modules
{
    public abstract class Module
    {

        public DateTime StartTime { get; set; }
        public DateTime EndTime
        {
            get
            {
                return StartTime + TimeSpan.FromMinutes(Duration);
            }

        }
        public virtual int Duration { get; set; }
        




    }
}
