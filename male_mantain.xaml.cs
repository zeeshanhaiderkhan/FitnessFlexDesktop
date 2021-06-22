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
    /// Interaction logic for male_mantain.xaml
    /// </summary>
    public partial class male_mantain : Window
    {
        public male_mantain()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chest_mm(object sender, RoutedEventArgs e)
        {
            chestmm cmm = new chestmm();
            cmm.Show();
            this.Hide();
        }

        private void back_mm(object sender, RoutedEventArgs e)
        {
            backmm bmm = new backmm();
            bmm.Show();
            this.Hide();
        }

        private void arm_mm(object sender, RoutedEventArgs e)
        {
            armmm amm = new armmm();
            amm.Show();
            this.Hide();
        }

        private void shld_mm(object sender, RoutedEventArgs e)
        {
            shldmm smm = new shldmm();
            smm.Show();
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
