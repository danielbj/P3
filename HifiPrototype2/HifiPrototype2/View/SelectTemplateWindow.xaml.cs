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
    /// Interaction logic for SelectTemplateWindow.xaml
    /// </summary>
    /// 
    public partial class SelectTemplateWindow : Window
    {
        private ScheduleView _schedule;

        public SelectTemplateWindow(ScheduleView schedule)
        {
            InitializeComponent();
            _schedule = schedule;

            foreach (GroupSchedule item in schedule.Templates)
            {
                TemplateScheduleListBox.Items.Add(item);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            int index = TemplateScheduleListBox.SelectedIndex;
            var item = TemplateScheduleListBox.SelectedItem as GroupSchedule;

            if(item != null)
            {
                MessageBoxResult r = MessageBox.Show(this, "Ved at indlæse en grundplan overskrives den nuværende. Er du sikker på at du vil fortsætte?", "Bekræft", MessageBoxButton.OKCancel);
                if (r == MessageBoxResult.OK)
                {
                    _schedule.SelectedGroupSchedule = item;
                    _schedule.LoadSchedule();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Vælg venligst en grundplan!");
            }

        }
    }
}
