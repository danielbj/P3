using HifiPrototype2.Functions;
using HifiPrototype2.Model;
using System;
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
        private Point _startPoint;
        public AssignmentMovedEventHandler AssignmentMovedEvent;
        private bool IsDragging = false;        

        private AssignmentView()
        {
            InitializeComponent();
            Presenter = new AssignmentPresenter();
            Presenter.SetView(this);
            AllowDrop = true;
            Drop += AssignmentView_Drop;
            PreviewMouseLeftButtonDown += AssignmentView_MouseDown;
            PreviewMouseMove += AssignmentView_PreviewMouseMove;
        }

        private void AssignmentView_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && !IsDragging)
            {
                Point position = e.GetPosition(null);

                if (Math.Abs(position.X - _startPoint.X) > SystemParameters.MinimumHorizontalDragDistance ||
                        Math.Abs(position.Y - _startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    StartDrag(sender, e);
                }
            }
        }

        private void StartDrag(object sender, MouseEventArgs e)
        {
            IsDragging = true;
            AssignmentView dragSource = sender as AssignmentView;

            if (dragSource != null)
            {
                DragDrop.DoDragDrop(dragSource, dragSource, DragDropEffects.Move);
            }
            IsDragging = false;
        }

        private void AssignmentView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(null);
        }

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

        private void JobButton_Click(object sender, RoutedEventArgs e)
        {
            EditJobWindow jobWindow = new EditJobWindow(this);
            jobWindow.ShowDialog();
        }
    }
}
