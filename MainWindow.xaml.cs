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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        //public static Stack<Window> backStack = new Stack<Window>();
        public MainWindow()
        {
            InitializeComponent();
        }
        
        

        public void ChangeRandom(object sender, RoutedEventArgs e)
        {
            System.Collections.ObjectModel.ReadOnlyCollection<Theme> colors = ThemeManager.Current.Themes;
            
             Random rnd = new Random();
            int r =rnd.Next(colors.Count());
            
            if (ThemeManager.Current.DetectTheme(this).Equals(colors[r].Name))
            {
                return;
            }
            else
            {
                ThemeManager.Current.ChangeTheme(this,colors[r].Name);
            }
        }


        private void OpenMembers(object sender, RoutedEventArgs e)
        {
            Members newWin = new Members();
            newWin.Show();
        }
        private void OpenFees(object sender, RoutedEventArgs e)
        {
            Fees newWin = new Fees();
            newWin.Show();
        }
        private void OpenReports(object sender, RoutedEventArgs e)
        {
            Reports newWin = new Reports();
            newWin.Show();
        }
        private void OpenDietPlans(object sender, RoutedEventArgs e)
        {
            Select_Gender newWin = new Select_Gender();
            newWin.Show();
        }
        private void OpenWorkoutPlans(object sender, RoutedEventArgs e) 
        {
            Window newWin = new Exercise_plan.Workoutplan();
            newWin.Show();
        }
        private void OpenAttendances(object sender, RoutedEventArgs e)
        {
            Attendances newWin = new Attendances();
            newWin.Show();
        }
        /*
        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            if (((Tile)sender).Name.Equals("DietPlans")){
                ((Tile)sender).Name = "Select_Gender";
            }

            

            try { 

            Type t = Type.GetType(((string)"FitnessFlex."+(((Tile)sender).Name)));
            
            var winType = Activator.CreateInstance(t);
            Window newWin = (Window)winType;
            newWin.Show();
            //this.Close();
            //this.Hide();
            //backStack.Push(this);
            }
            catch (Exception)
            {
                Window nw = new Exercise_plan.Workoutplan();
                nw.Show();
                //this.Close();
            }
        }*/

        private void signOutBtn_Click(object sender, RoutedEventArgs e)
        {
            LogIn li = new LogIn();
            li.Show();
            this.Close();
        }
    }
}
