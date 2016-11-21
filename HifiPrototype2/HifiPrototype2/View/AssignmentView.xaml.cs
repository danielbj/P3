using HifiPrototype2.Functions;
using HifiPrototype2.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HifiPrototype2.View
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
        }

        public void LoadAssignment()
        {
            Description.Text = Presenter.Description;
            Duration.Text = Presenter.Duration.ToString();
            Location.Text = Presenter.Location.ToString();
        }

        private void UserControl_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            var b = sender as AssignmentView;
            b.ToolTip = b.Description.Text + "\n" + b.Duration.Text + "\n" + b.Location.Text;
        }
    }
}
