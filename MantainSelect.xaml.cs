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
    /// Interaction logic for MantainSelect.xaml
    /// </summary>
    public partial class MantainSelect : Window
    {
        public MantainSelect()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void submit_clicked(object sender, RoutedEventArgs e)
        {
            if ((bool)male.IsChecked)
            {
                male_mantain mm = new male_mantain();
                mm.Show();
                this.Hide();
            }
            else if ((bool)female.IsChecked)
            {
                female_mantain fmm = new female_mantain();
                fmm.Show();
                this.Hide();
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
