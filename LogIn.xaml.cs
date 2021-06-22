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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        Dictionary<string, string> logData = new Dictionary<string, string>();

        public LogIn()
        {
            InitializeComponent();
            logData.Add("zeeshan@gmail.com", "iamzeeshan");
            logData.Add("taha@gmail.com", "iamtaha");
            logData.Add("sherry@gmail.com", "iamsherry");
        }

        public void Email_focus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Email_focus;       
        }

        public void password_focus(object sender, RoutedEventArgs e)
        {
            PasswordBox tb = (PasswordBox)sender;
            tb.Password = string.Empty;
            tb.GotFocus -= password_focus;
        }

        private void sigInBtn_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if (logData[email.Text].Equals(pwd.Password))
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid E-mail or Password!");
            }
            
            
        }

        private void pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {

            
                sigInBtn_Click(sender, new RoutedEventArgs());
            }
        }
    }
}
