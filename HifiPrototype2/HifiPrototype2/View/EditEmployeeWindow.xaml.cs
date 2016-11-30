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
    /// Interaction logic for EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        public EditEmployeeWindow() //Employee empl
        {
            InitializeComponent();
            //this._employee = empl;
        }

        private void FillFields()
        {
            //EmployeeNameTextBox.Text = _employee.Name;
            //EmployeePhoneTextBox.Text = _employee.PhoneNumber;
            //EmployeeGroupComboBox.SelectedItem = _employee.Group;
            //EmployeePositionComboBox.SelectedItem = _employee.Position;

            EmployeeNameTextBox.Text = "Navn";
            EmployeePhoneTextBox.Text = "12345678";
        }

        private void SaveEmployeeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
