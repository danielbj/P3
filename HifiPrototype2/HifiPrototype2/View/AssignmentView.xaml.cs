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
    public delegate void AssignmentMovedEventHandler(Assignment target, Assignment source);
    /// <summary>
    /// Interaction logic for AssignmentView.xaml
    /// </summary>
    public partial class AssignmentView : UserControl
    {
        public AssignmentPresenter Presenter;
        private AssignmentView()
        {
            InitializeComponent();
            Presenter = new AssignmentPresenter();
            Presenter.SetView(this);
            AllowDrop = true;
            Drop += AssignmentView_Drop;
            PreviewMouseDown += AssignmentView_MouseDown;
        }

        private void AssignmentView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AssignmentView dragSource = sender as AssignmentView;
            

            if (dragSource!= null)
            {
                DragDrop.DoDragDrop(dragSource, dragSource, DragDropEffects.Move);
            }
        }

        public AssignmentMovedEventHandler AssignmentMovedEvent;

        private void AssignmentView_Drop(object sender, DragEventArgs e)
        {
            AssignmentView targetAV = sender as AssignmentView;
            AssignmentView sourceAV = e.Data.GetData(typeof(AssignmentView)) as AssignmentView;

            if (targetAV != null & sourceAV != null)
            {
                var target = targetAV.Presenter.Assignment;
                var source = sourceAV.Presenter.Assignment;
                Presenter.MoveAssignment(target, source);
                //AssignmentMovedEvent(target, source);
                
            }
        }

        public AssignmentView(Assignment assignment): this()
        {
            Presenter.SetAssignment(assignment);
            LoadAssignment();
            Height = Presenter.Duration;
        }

        public void LoadAssignment()
        {
            Description.Text = Presenter.Description;
            Duration.Text = Presenter.Duration.ToString();
            Location.Text = Presenter.Location.ToString();
        }
    }
}
