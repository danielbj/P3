﻿using System;
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
using Planning.ViewModel;

namespace Planning.View
{
    /// <summary>
    /// Interaction logic for EmployeeDeleteWindow.xaml
    /// </summary>
    public partial class EmployeeDeleteWindow : Window
    {
        private EmployeeDeleteViewModel VM;
        public EmployeeDeleteWindow()
        {
            DataContext = VM = new EmployeeDeleteViewModel();
            InitializeComponent();
        }
    }
}
