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
        public static Stack<Window> backStack = new Stack<Window>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LaunchGitHubSite(object sender, RoutedEventArgs e)
        {
            // Launch the GitHub site...
        }

        private void DeployCupCakes(object sender, RoutedEventArgs e)
        {
            // deploy some CupCakes...
        }
        public void ChangeTheme(object sender, RoutedEventArgs e)
        {
            if (this.themeTogg.IsOn)
            {
                ThemeManager.Current.ChangeTheme(this, "Light.Blue");
            }
            if(!this.themeTogg.IsOn) { 
            ThemeManager.Current.ChangeTheme(this, "Dark.Yellow");
            }
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

        

        private void OpenWindow(object sender, RoutedEventArgs e)
        {

            Type t = Type.GetType(((string)"FitnessFlex."+(((Tile)sender).Name)));
            var winType = Activator.CreateInstance(t);
            Window newWin = (Window)winType;
            newWin.Show();
            //this.Hide();
            backStack.Push(this);
        }
        
    }
}
