using Planning.Modules;
using System;
using System.Collections.Generic;

namespace Planning.Schedules
{
    public abstract class Schedule
    {
        public abstract string Name { get; }                                        // Name or title
        public abstract string Description { get; set; }                            // Might be a method to collect data from container element
       
        public virtual bool Approved { get; private set; }                          // Shows state of aproval
        public virtual bool IsSaved { get; private set; } = false;                  // Shows if saved or not

        private List<Module> _module = new List<Module>();                          // List of all elements in schedule

        /// <summary>
        /// Initialises a schedule
        /// </summary>
        public Schedule()
        { }

        /// <summary>
        /// Moves element
        /// </summary>
        public abstract void MoveModule();

        /// <summary>
        /// Adds an element to list
        /// </summary>
        /// <param name="module">Used to add to schedule</param>
        public virtual void AddModule(Module module)
        { }

        /// <summary>
        /// Deletes an element
        /// </summary>
        /// <param name="module">Used to remove correct element</param>
        public virtual void DeleteElement(Module module)
        {
            _module.Remove(module);

            IsSaved = false;
        }

        /// <summary>
        /// Clears all data from schedule
        /// </summary>
        public abstract void DeleteSchedule();

        /// <summary>
        /// Saves data and updates
        /// </summary>
        public abstract void Save();

        /// <summary>
        /// Set state of Approved variable
        /// </summary>
        /// <param name="state">Indicate approve status</param>
        public abstract void Approve(bool state);
    }
}

