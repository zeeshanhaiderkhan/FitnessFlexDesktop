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
using System.Configuration;


namespace FitnessFlex
{
    /// <summary>
    /// Interaction logic for Members.xaml
    /// </summary>
    public partial class Members : MetroWindow
    {
        FitnessFlexDB db = new FitnessFlexDB();
        public Members()
        {
            InitializeComponent();
            this.memberList.ItemsSource = db.Members.ToList();
            this.memberData.ItemsSource = db.Members.ToList();



        }
        private void ChangeDataView(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn)
                {
                    this.memberList.Visibility = Visibility.Hidden;
                    this.memberData.Visibility = Visibility.Visible;
                    this.memberData.Columns[10].Visibility = Visibility.Hidden;
                }
                else
                {
                    this.memberList.Visibility = Visibility.Visible;
                    this.memberData.Visibility = Visibility.Hidden;
                }
            }
        }

        private void AddMember(object sender, RoutedEventArgs e)
        {
            MemberAU add = new MemberAU(false, null);
            add.Show();


        }
        private void EditMember(object sender, RoutedEventArgs e)
        {

            if(memberList.SelectedItem != null) { 
            Member m = (Member)memberList.SelectedItem;

            MemberAU add = new MemberAU(true, m);
            add.Show();
            }
            else
            {
                MessageBox.Show("Select Member!");
            }
            //this.Refresh(new object(),new RoutedEventArgs());

        }
        
        private void DeleteMember(object sender, RoutedEventArgs e)
        {
            if (memberList.SelectedItem != null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Member", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes) { 
                    foreach (Fee f in db.Fees.ToList().Where(fee => fee.MemberID.Equals(((Member)this.memberList.SelectedItem).Id)))
                {
                    db.Fees.Remove(f);
                }

                db.Members.Remove((Member)this.memberList.SelectedItem);
                db.SaveChanges();
                this.Refresh(new object(), new RoutedEventArgs());
                }

            }
            else
            {
                MessageBox.Show("Select Member!");
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            this.memberList.ItemsSource = db.Members.ToList();
            this.memberData.ItemsSource = db.Members.ToList();

        }
        private void Search(object sender, RoutedEventArgs e)
        {
            this.memberList.ItemsSource = db.Members.ToList().Where(mem => mem.Id.ToString().Contains(searchTxtBox.Text));
        }
        private void SearchEnter(object sender, KeyEventArgs e)
        {
            this.Search(sender, new RoutedEventArgs());
        }

       private void SearchChanged(object sender, TextChangedEventArgs args)
        {
            this.Search(sender, new RoutedEventArgs());
        }

        
    }
}