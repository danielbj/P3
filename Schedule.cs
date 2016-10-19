using System;
using System.Collections.Generic;
namespace Planner
{
    public abstract class Schedule
    {
        public string Name { get; }                                                 // Name or title
        public string Description { get; set; }                                     // Might be a method to collect data from container element

        public bool Approved { get; private set; }                                  // Shows state of aproval
        public bool IsSaved { get; private set; } = false;                          // Shows if saved or not

        private List<ContainerElement> elements = new List<ContainerElement>();     // List of all elements in schedule


        /// <summary>
        /// Initialises a schedule
        /// </summary>
        public Schedule()
        {

        }

        /// <summary>
        /// Moves element
        /// </summary>
        public void MoveElement()
        { }

        
        /// <summary>
        /// Clears all data from schedule
        /// </summary>
        public void DeleteSchedule()
        {
            // Initialise all variables. Ex:
            ////elements.Clear();
        }

        /// <summary>
        /// Saves data and updates
        /// </summary>
        public void Save()
        {
            // Update PDA

            // Set save state to false
        }

        /// <summary>
        /// Set state of Approved variable
        /// </summary>
        /// <param name="state">Indicate approve status</param>
        public void Approve(bool state)
        {
            
        }
    }
}

