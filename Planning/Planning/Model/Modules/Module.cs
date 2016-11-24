using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model.Modules
{
    public abstract class Module : IModule
    {
        public int _startTime { get; set; } // Maybe DateTime
        public int _endTime { get; set; } //Maybe DateTime
        public string _name { get; set; } // May be prop
        public abstract string Description { get; }
        public abstract string Duration { get; }

        public Module(int startTime, string name)
        {
            _startTime = startTime;
            _name = name;
        }

        /// <summary>
        /// Gets the duration of the Module
        /// </summary>

        /// <summary>
        /// Calculates the size of the module
        /// </summary>
        /// <returns>Size of module</returns>
        public abstract int CalculateSize();

        /// <summary>
        /// Returns a relevent description of the module
        /// </summary>
        /// <returns>Description</returns>
        

    }
}
