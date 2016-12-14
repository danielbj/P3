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
    /// Interaction logic for Mailbox.xaml
    /// </summary>
    public partial class Mailbox : UserControl
    {
        MailboxViewModel VM;
        public Mailbox() {
            InitializeComponent();
            DataContext = VM = new MailboxViewModel();
            VM.ChangeOfList += VM_ChangeOfList;
            
        }

        private void VM_ChangeOfList() {
            Messagelist.Items.Refresh();
        }
        
    }
}
