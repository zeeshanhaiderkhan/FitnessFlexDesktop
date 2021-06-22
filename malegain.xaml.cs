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
    /// Interaction logic for malegain.xaml
    /// </summary>
    public partial class malegain : Window
    {
        public malegain()
        {
            InitializeComponent();
        }

        private void chest_mg(object sender, RoutedEventArgs e)
        {
            chestmg cmg = new chestmg();
            cmg.Show();
            this.Hide();
        }

        private void back_mg(object sender, RoutedEventArgs e)
        {
            backmg bmg = new backmg();
            bmg.Show();
            this.Hide();
        }

        private void arm_mg(object sender, RoutedEventArgs e)
        {
            armmg amg = new armmg();
            amg.Show();
            this.Hide();
        }

        private void shld_mg(object sender, RoutedEventArgs e)
        {
            shldmg smg = new shldmg();
            smg.Show();
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
