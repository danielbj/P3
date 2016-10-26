using System;
using System.Collections.Generic;
namespace Planner
{
    public abstract class Schedule
    {
        public string Name { get; }                                                 // Name or title
        public string Description { get; set; }                                     // Might be a method to collect data from container element
       
        public virtual bool Approved { get; private set; }                          // Shows state of aproval
        public virtual bool IsSaved { get; private set; } = false;                  // Shows if saved or not

        private List<ContainerElement> _elements = new List<ContainerElement>();     // List of all elements in schedule

        /// <summary>
        /// Initialises a schedule
        /// </summary>
        public Schedule()
        { }

        /// <summary>
        /// Moves element
        /// </summary>
        public abstract void MoveElement()
        { }

        /// <summary>
        /// Adds an element to list
        /// </summary>
        /// <param name="element">Used to add to schedule</param>
        public virtual void AddElement(Element element)
        { }

        /// <summary>
        /// Deletes an element
        /// </summary>
        /// <param name="element">Used to remove correct element</param>
        public virtual void DeleteElement(Element element)
        {
            _elements.Remove(element);

            IsSaved = false;
        }
        
        /// <summary>
        /// Clears all data from schedule
        /// </summary>
        public abstract void DeleteSchedule()
        {
            // Initialise all variables. Ex:
            ////elements.Clear();
        }

        /// <summary>
        /// Saves data and updates
        /// </summary>
        public abstract void Save()
        {
            // Update PDA

            // Set save state to true
        }

        /// <summary>
        /// Set state of Approved variable
        /// </summary>
        /// <param name="state">Indicate approve status</param>
        public abstract void Approve(bool state)
        { }
    }
}

