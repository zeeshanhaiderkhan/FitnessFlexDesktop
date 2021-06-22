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
    /// Interaction logic for female_mantain.xaml
    /// </summary>
    public partial class female_mantain : Window
    {
        public female_mantain()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chest_fm(object sender, RoutedEventArgs e)
        {
            chestfm cfm = new chestfm();
            cfm.Show();
            this.Hide();
        }

        private void back_fm(object sender, RoutedEventArgs e)
        {
            backfm bfm = new backfm();
            bfm.Show();
            this.Hide();
        }

        private void arm_fm(object sender, RoutedEventArgs e)
        {
            armfm afm = new armfm();
            afm.Show();
            this.Hide();
        }

        private void shld_fm(object sender, RoutedEventArgs e)
        {
            shldfm sfm = new shldfm();
            sfm.Show();
            this.Hide();
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            Workoutplan wp = new Workoutplan();
            this.Close();
            wp.Show();
        }

    }
}
