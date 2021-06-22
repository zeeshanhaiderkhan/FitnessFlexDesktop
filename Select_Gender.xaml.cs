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
using MahApps.Metro.Controls;
using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;

namespace FitnessFlex
{
    /// <summary>
    /// Interaction logic for Select_Gender.xaml
    /// </summary>
    public partial class Select_Gender : MetroWindow
    {
        public int a = 0;
        public int b = 0;
        public int c = 0;
        public int d = 0;

        public Select_Gender()
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this,"Light.Yellow");
        }

        private void SelectTileGoal(object sender, RoutedEventArgs e)
        {

            Tile t1 = (Tile)sender;
            if (t1.Title.Equals("Gain Weight"))
            {

                t1.Background = Brushes.Teal;
                a = 1;
                b = 0;
                loose_weight.Background = Brushes.Yellow;
            }
            else 
            {
                loose_weight.Background = Brushes.Teal;
                b = 1;
                a = 0;
                gain_weight.Background = Brushes.Yellow;
            }
        }

        private void SelectGender (object sender , RoutedEventArgs e)
        {
            Tile t1 = (Tile)sender;
            if (t1.Title.Equals("MALE"))
            {

                t1.Background = Brushes.Teal;
                c = 1;
                d = 0;
                female.Background = Brushes.Yellow;
            }
            else
            {
                female.Background = Brushes.Teal;
                d = 1;
                c = 0;
                male.Background = Brushes.Yellow;
            }
        }

     



        private void generate_Click(object sender, RoutedEventArgs e)
        {
            if(a == 1 && c == 1)
            {
                MaleGainDietPlan mgsp = new MaleGainDietPlan();
                this.Close();
                mgsp.Show();

            }

            else if (a == 1 && d ==1)
            {
                FemaleGainDietPlan fgdp = new FemaleGainDietPlan();
                this.Close();
                fgdp.Show();
            }

            else if (b == 1 && c == 1) 
            {
                MaleLooseDietPlan mldp = new MaleLooseDietPlan();
                this.Close();
                mldp.Show();
            }

            else if (b == 1 && d == 1)
            {
                FemaleLooseDietPlan fldp = new FemaleLooseDietPlan();
                this.Close();
                fldp.Show();
            }

            else
            {
                MessageBox.Show("Please Select Gender And Your Goal!");
            }
            
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show(); 
            this.Close();
        }
    }
}
