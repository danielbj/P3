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

namespace HifiPrototype2
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
            ScheduleGrid.ShowGridLines = true;
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
            //DailySchedulePanel.Children.Add(assignment);
        }

        //public void AddEmployee(Employee employee) {
        //    DailySchedulePanel.Children.Add(employee);
        //}

        public void Clear()
        {
            //DailySchedulePanel.Children.Clear();
        }



        private void DailySchedulePanel_Drop(object sender, DragEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            Button btn = e.Data.GetData(typeof(Button)) as Button;

            if (sp != null)
            {
                StackPanel parent = btn.Parent as StackPanel;
                parent.Children.Remove(btn);
                sp.Children.Add(btn);
            }
        }

    }
}
