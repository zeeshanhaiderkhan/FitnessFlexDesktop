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
    /// Interaction logic for FatSelect.xaml
    /// </summary>
    public partial class FatSelect : Window
    {
        public FatSelect()
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
                malelose ml = new malelose();
                ml.Show();
                this.Hide();
            }
            else if ((bool)female.IsChecked)
                    { 
                femalelose fml = new femalelose();
                fml.Show();
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