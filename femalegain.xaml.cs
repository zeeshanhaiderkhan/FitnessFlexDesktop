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
    /// Interaction logic for femalegain.xaml
    /// </summary>
    public partial class femalegain : Window
    {
        public femalegain()
        {
            InitializeComponent();
        }

        private void chest_fg(object sender, RoutedEventArgs e)
        {
            chestfg cfg = new chestfg();
            cfg.Show();
            this.Hide();
        }

        private void back_fg(object sender, RoutedEventArgs e)
        {
            backfg bfg = new backfg();
            bfg.Show();
            this.Hide();
        }

        private void arm_fg(object sender, RoutedEventArgs e)
        {
            armfg afg = new armfg();
            afg.Show();
            this.Hide();
        }

        private void shld_fg(object sender, RoutedEventArgs e)
        {
            shldfg sfg = new shldfg();
            sfg.Show();
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
