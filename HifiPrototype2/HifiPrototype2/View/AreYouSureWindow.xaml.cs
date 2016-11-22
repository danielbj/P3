using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AreYouSureWindow.xaml
    /// </summary>
    public partial class AreYouSureWindow : Window, INotifyPropertyChanged
    {
        public bool IsAccepted { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;


        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description)
                    return;

                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public AreYouSureWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public AreYouSureWindow(string description)
            : this()
        {
            Description = description;
        }

        public void ShowDialog(Window owner)
        {
            Owner = owner;
            ShowDialog();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            IsAccepted = true;
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            IsAccepted = false;
            Close();
        }
    }
}
