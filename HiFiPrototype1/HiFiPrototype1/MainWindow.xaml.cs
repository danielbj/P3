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

namespace HiFiPrototype1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Rectangle r = null;

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle rectangle = sender as Rectangle;
            Point p = e.GetPosition(null);

            if (rectangle != null && e.LeftButton == MouseButtonState.Pressed)
            {
                r = rectangle;
                DragDrop.DoDragDrop(rectangle, rectangle, DragDropEffects.Move);
            }

        }

        private void gridGrupper_Drop(object sender, DragEventArgs e)
        {
            Grid g = sender as Grid;

            if (r != null && g != null)
            {
                r.Margin = new Thickness(e.GetPosition(g).X, e.GetPosition(g).Y, 0, 0);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            b.Content = "Hej";
        }

        private void gridGrupper_DragOver(object sender, DragEventArgs e)
        {
            //Grid g = sender as Grid;

            //if (r != null && g != null)
            //{
            //    r.Margin = new Thickness(e.GetPosition(g).X, e.GetPosition(g).Y, 0, 0);
            //}
        }
    }
}
