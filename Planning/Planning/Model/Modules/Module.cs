using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model.Modules
{
    public abstract class Module
    {
        public int _startTime; // Maybe DateTime
        public int _endTime; //Maybe DateTime
        public string _name; // May be prop

        public Module(int startTime, string name)
        {
            _startTime = startTime;
            _name = name;
        }

        /// <summary>
        /// Gets the duration of the Module
        /// </summary>
        public abstract string Duration { get; }

        /// <summary>
        /// Calculates the size of the module
        /// </summary>
        /// <returns>Size of module</returns>
        public abstract int CalculateSize();

        /// <summary>
        /// Returns a relevent description of the module
        /// </summary>
        /// <returns>Description</returns>
        public abstract string Description();

    }
}
