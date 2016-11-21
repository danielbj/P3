using HifiPrototype2.Functions;
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
using HifiPrototype2.View;

namespace HifiPrototype2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowPresenter _presenter;
        public MainWindow()
        {
            InitializeComponent();
            _presenter = new MainWindowPresenter();
            _presenter.SetView(this);
            DataContext = _presenter;
        }

        private void addEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            _presenter.AddRandomEmployee();

            

        }


        private void addTask_Click(object sender, RoutedEventArgs e)
        {
            //_presenter.AddRandomAssignment();

            //Assignment a = Assignment.CreateRandomAssignment();
            //var btn = new Button();
            //btn.Content = a.Description;
            //btn.Height = a.Duration;
            //btn.PreviewMouseMove += Btn_PreviewMouseMove;
            //taskHolder.Children.Add(btn);

        }

        private void MailBoxButton_Click(object sender, RoutedEventArgs e)
        {
            var MailWindow = new MailBoxWindow();
            MailWindow.Show();
        }
    }
}
