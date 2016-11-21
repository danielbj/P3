using HifiPrototype2.Model;
using HifiPrototype2.View;

namespace HifiPrototype2.Functions
{
    public class AssignmentPresenter
    {
        private AssignmentView _view;
        public Assignment Assignment;

        public string Description
        {
            get
            {
                return Assignment.Description;
            }
            set
            {
                Assignment.Description = value;
            }
        }

        public int Duration
        {
            get
            {
                return Assignment.Duration;
            }
            set
            {
                Assignment.Duration = value;
            }
        }

        public int Location
        {
            get
            {
                return Assignment.Location;
            }
            set
            {
                Assignment.Location = value;
            }
        }

        public int PanelWidth { get; set; } = 100;

        public AssignmentPresenter()
        {
         
        }

        public void SetView(AssignmentView view)
        {
            _view = view;
        }

        public void SetAssignment(Assignment assignment)
        {
            Assignment = assignment;
        }

        internal void MoveAssignment(Assignment target, Assignment source)
        {
            Employee targetEmployee = target.Provider;
            Employee sourceEmployee = source.Provider;
            
            // TODO sørg for at target != source 
            int targetIndex = targetEmployee.Assignments.IndexOf(target);
 
            sourceEmployee.RemoveAssignment(source);
            targetEmployee.InsertAssignment(targetIndex, source);
            
        }
    }
}
