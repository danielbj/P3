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
using Planning.ViewModel;

namespace Planning.View
{
    /// <summary>
    /// Interaction logic for TaskItemVieww.xaml
    /// </summary>
    public partial class TaskItemView : UserControl
    {
        public TaskItemViewModel VM;
        public TaskItemView()
        {
            InitializeComponent();
            //DataContext = VM = new TaskItemViewModel();
        }
    }
}
