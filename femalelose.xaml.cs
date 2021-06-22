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
    /// Interaction logic for femalelose.xaml
    /// </summary>
    public partial class femalelose : Window
    {

        public femalelose()
        {
        
            InitializeComponent();
        }

        private void chest_fl(object sender, RoutedEventArgs e)
        {
            chestfl cfl = new chestfl();
            cfl.Show();
            this.Hide();
        }

        private void back_fl(object sender, RoutedEventArgs e)
        {
            backfl bfl = new backfl();
            bfl.Show();
            this.Hide();
        }

        private void arm_fl(object sender, RoutedEventArgs e)
        {
            armfl afl = new armfl();
            afl.Show();
            this.Hide();
        }

        private void shld_fl(object sender, RoutedEventArgs e)
        {
            shldfl sfl = new shldfl();
            sfl.Show();
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
