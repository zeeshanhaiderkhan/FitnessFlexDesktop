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

namespace FitnessFlex
{
    /// <summary>
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Window
    {
        public Invoice(Member member, Fee fee)
        {
            InitializeComponent();
            this.DataContext = fee;
            this.memberId.Text = member.Id.ToString();
            this.memberName.Text = member.Name;
            this.dateToday.Text = DateTime.Now.ToString();
            this.memberPackage.Text = member.Package;
            //this.gymAddress.Text = CustomSettings.GetAddress();
        }

        private void PrintInvoice(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                this.printBtn.Visibility = Visibility.Hidden;
                PrintDialog printDialog = new PrintDialog();
                if ((bool)printDialog.ShowDialog())
                {
                    printDialog.PrintVisual(invoiceGrid, "PrintInvoice_" + DateTime.Now.ToString());
                }
            }
            finally
            {
                this.IsEnabled = true;
                this.printBtn.Visibility = Visibility.Visible;
            }
        }
    }
}
