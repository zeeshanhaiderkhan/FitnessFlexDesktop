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
    /// Interaction logic for malelose.xaml
    /// </summary>
    public partial class malelose : Window
    {
        public malelose()
        {
            InitializeComponent();
        }
        private void chest_ml(object sender, RoutedEventArgs e)
        {
            chestml cml = new chestml();
            cml.Show();
            this.Hide();
        }

        private void back_ml(object sender, RoutedEventArgs e)
        {
            backml bml = new backml();
            bml.Show();
            this.Hide();
        }

        private void arm_ml(object sender, RoutedEventArgs e)
        {
            armml aml = new armml();
            aml.Show();
            this.Hide();
        }

        private void shld_ml(object sender, RoutedEventArgs e)
        {
            shldml sml = new shldml();
            sml.Show();
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
