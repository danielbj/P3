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

namespace HifiPrototype2.View
{
    /// <summary>
    /// Interaction logic for SelectEmployeeWindow.xaml
    /// </summary>
    public partial class SelectEmployeeWindow : Window
    {
        private DailyScheduleView _dailySchedule;

        public SelectEmployeeWindow(DailyScheduleView dailySchedule)
        {
            InitializeComponent();
            _dailySchedule = dailySchedule;
        }

        private void EmployeeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = EmployeeListBox.SelectedItem as ListBoxItem;

            _dailySchedule.NameLabel.Text = item.Content as string;
            this.Close();
        }
    }
}
