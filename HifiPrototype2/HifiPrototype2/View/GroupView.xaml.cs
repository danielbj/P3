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
    /// Interaction logic for GroupView.xaml
    /// </summary>
    public partial class GroupView : UserControl
    {
        public GroupView()
        {
            InitializeComponent();
        }

        private void EditEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new EditEmployeeWindow();
            window.Show();
        }

        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExpandAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in EmployeePanel.Children)
            {
                Expander exp = item as Expander;
                exp.IsExpanded = true;
            }
        }

        private void CollapseAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in EmployeePanel.Children)
            {
                Expander exp = item as Expander;
                exp.IsExpanded = false;
            }
        }
    }
}
