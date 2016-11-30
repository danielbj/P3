using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using HifiPrototype2.Model;

namespace HifiPrototype2.View
{
    /// <summary>
    /// Interaction logic for PopupWindow.xaml
    /// </summary>
    public partial class EditJobWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        AssignmentView Job;

        public string Description
        {
            get
            {
                return (Job != null ? Job.Description.Text : string.Empty);
            }
            set
            {
                if (value == Job.Description.Text)
                    return;

                Job.Description.Text = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Duration
        {
            get
            {
                return (Job != null ? Job.Duration.Text : string.Empty);
            }
            set
            {
                if (value == Job.Duration.Text)
                    return;

                Job.Duration.Text = value;
                OnPropertyChanged(nameof(Duration));
            }
        }

        public string Location
        {
            get
            {
                return (Job != null ? Job.Location.Text : string.Empty);
            }
            set
            {
                if (value == Job.Location.Text)
                    return;

                Job.Location.Text = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        public EditJobWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public EditJobWindow(object sender)
            : this()
        {
            if (sender is AssignmentView)
                Job = sender as AssignmentView;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Job.LoadAssignment();
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Job.Presenter.Description = Description;
            Job.Presenter.Duration = int.Parse(Duration);
            Job.Presenter.Location = int.Parse(Location);
            Job.Presenter.Assignment.Provider.AdjustTime();
            Job.Presenter.Assignment.Provider.RaiseAssignmentsChanged();
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            AreYouSureWindow newWindow = new AreYouSureWindow("Er du sikker på at du vil fjerne opgaven?");

            newWindow.ShowDialog(this);

            if (newWindow.IsAccepted)
            {
                Assignment a = Job.Presenter.Assignment;
                EmployeeSchedule es = a.EmployeeSchedule;
                GroupSchedule g = es.GroupSchedule;

                es.RemoveAssignment(a);
                g.UnplanAssignment(a);
                
                
                Close();
            }

        }
    }
}
