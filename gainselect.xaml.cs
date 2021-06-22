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

namespace Exercise_plan
{
    /// <summary>
    /// Interaction logic for gainselect.xaml
    /// </summary>
    public partial class gainselect : Window
    {
        public gainselect()
        {
            InitializeComponent();
        }

        private void submit_clicked(object sender, RoutedEventArgs e)
        {
            if ((bool)male.IsChecked)
            {
                malegain mg = new malegain();
                mg.Show();
                this.Hide();
            }
            else if ((bool)female.IsChecked)
            {
                femalegain fg = new femalegain();
                fg.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Select Gender!");
            }
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            Workoutplan wp = new Workoutplan();
            this.Close();
            wp.Show();
        }

    }
}
