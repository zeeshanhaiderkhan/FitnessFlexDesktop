using ControlzEx.Theming;
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

namespace FitnessFlex
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }
        public void ChangeRandom(object sender, RoutedEventArgs e)
        {
            System.Collections.ObjectModel.ReadOnlyCollection<Theme> colors = ThemeManager.Current.Themes;

            Random rnd = new Random();
            int r = rnd.Next(colors.Count());

            if (ThemeManager.Current.DetectTheme(this).Equals(colors[r].Name))
            {
                return;
            }
            else
            {
                ThemeManager.Current.ChangeTheme(this, colors[r].Name);
            }
        }

        public void BackButton(object sender, RoutedEventArgs e)
        {
            //MainWindow.backStack.Pop().Show();
            this.Close();
        }
    }
}
