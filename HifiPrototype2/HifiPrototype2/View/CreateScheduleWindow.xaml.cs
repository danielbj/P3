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
using System.Windows.Shapes;
using HifiPrototype2.Model;

namespace HifiPrototype2.View
{
    /// <summary>
    /// Interaction logic for CreateScheduleWindow.xaml
    /// </summary>
    public partial class CreateScheduleWindow : Window
    {
        private bool _isScheduleSelected;
        private Group group;

        public CreateScheduleWindow(Group group)
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var box = sender as ComboBox;

            if (box!=null)
            {
                if (box.SelectedIndex == 0)
                {
                    _isScheduleSelected = true;
                    //ScheduleGrid.Visibility = Visibility.Visible;
                    //TemplateGrid.Visibility = Visibility.Collapsed;
                }
                else
                {
                    _isScheduleSelected = false;
                    //ScheduleGrid.Visibility = Visibility.Collapsed;
                    //TemplateGrid.Visibility = Visibility.Visible;
                }
            }
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
 
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
