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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercise_plan
{
    /// <summary>
    /// Interaction logic for WorkoutPlans.xaml
    /// </summary>
    public partial class Workoutplan : Window
    {
        public Workoutplan()
        {
            InitializeComponent();
        }
             private void FatClick(object sender, RoutedEventArgs e)
        {
            FatSelect FS = new FatSelect();
            FS.Show();
            this.Hide();
        }

        private void Gain_Click(object sender, RoutedEventArgs e)
        {
            gainselect GS = new gainselect();
            GS.Show();
            this.Hide();
        }

        private void Mantain_Click(object sender, RoutedEventArgs e)
        {
            MantainSelect MS = new MantainSelect();
            MS.Show();
            this.Hide();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            FitnessFlex.MainWindow mw = new FitnessFlex.MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
