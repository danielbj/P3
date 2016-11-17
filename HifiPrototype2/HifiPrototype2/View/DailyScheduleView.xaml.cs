using HifiPrototype2.Functions;
using HifiPrototype2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HifiPrototype2.View
{
    /// <summary>
    /// Interaction logic for DailyScheduleView.xaml
    /// </summary>
    public partial class DailyScheduleView : UserControl
    {
        public DailySchedulePresenter Presenter;
        

        public DailyScheduleView()
        {
            InitializeComponent();
            Presenter = new DailySchedulePresenter();
            Presenter.SetView(this);

            ScheduleGrid.Height = 660;
            for (int i = 0; i < 660; i++) {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = new GridLength(1, GridUnitType.Star);

                ScheduleGrid.RowDefinitions.Add(rowdef);
            }
            
            
        }

        public DailyScheduleView(Employee employee) : this()
        {
            Presenter.SetEmployee(employee);
            Presenter.LoadAssignments();
        }

        public void AddAssignment(AssignmentView assignment)
        {
            

            ScheduleGrid.Children.Add(assignment);
            Grid.SetRow(assignment, assignment.Presenter.Assignment.StartTime);
            Grid.SetRowSpan(assignment, (int)assignment.Height); //Problem with grid and placement.


        }

        //public void AddEmployee(Employee employee) {
        //    DailySchedulePanel.Children.Add(employee);
        //}

        public void Clear()
        {
            ScheduleGrid.Children.Clear();
        }

        private void ScheduleGrid_Drop(object sender, DragEventArgs e)
        {
            AssignmentView sourceAV = e.Data.GetData(typeof(AssignmentView)) as AssignmentView;
            Grid sg = sender as Grid;


            if (sg != null && sourceAV != null)
            {
                var source = sourceAV.Presenter.Assignment;
                sourceAV.Presenter.Assignment.Provider.RemoveAssignment(source);
                Presenter._employee.AddAssignment(source);
                //AssignmentMovedEvent(target, source);
            }
        }

        private void ScheduleGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Contextmenu.IsOpen = true;
            
            
        }

        private void MenuItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DailyScheduleView dsv = sender as DailyScheduleView;

            if (dsv != null)
            {
                StackPanel sp = dsv.Parent as StackPanel;
                sp.Children.Remove(dsv);
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            StackPanel sp = this.Parent as StackPanel;
            sp.Children.Remove(this);
        }


        //private void ScheduleGrid_Drop(object sender, DragEventArgs e) {
        //    Grid grid = sender as Grid;
        //    Button btn = e.Data.etData(typeof(Button)) as Button;

        //    if (grid != null) {
        //        Grid parent = btn.Parent as Grid;
        //        parent.Children.Remove(btn);
        //        grid.Children.Add(btn);
        //    }
        //}
    }
}
