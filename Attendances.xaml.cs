using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Attendance.xaml
    /// </summary>
    public partial class Attendances : MetroWindow
    {
        FitnessFlexDB db = new FitnessFlexDB();
        public Attendances()
        {
            InitializeComponent();
            RefreshData();
        }

        private void addAttBtn_Click(object sender, RoutedEventArgs e)
        {
            int membId;
            try
            { 
                membId = int.Parse(this.memberId.Text);
            //bool cond2 = true;
            //MessageBox.Show(DateTime.Now.Date.ToShortDateString());

           
            //bool cond2 = db.Attendances.Where(a => a.MemberID.ToString().Equals(this.memberId.Text) && a.DOE.Value.Date.ToShortDateString().Equals(DateTime.Now.Date.ToShortDateString())).ToList().Count > 0;
            bool cond =   db.Attendances.Where(a => (a.MemberID.ToString().Equals(this.memberId.Text) )).ToList().Where(a => a.DOE.Value.Date.ToShortDateString().Equals(DateTime.Now.ToShortDateString())).ToList().Count > 0;    
            if (cond)
                {
                    MessageBox.Show("Attendance Already Exists!");
                }
                if (!cond )
                {
                    Attendance newAtt = new Attendance()
                    {
                        MemberID = int.Parse(this.memberId.Text),
                        DOE = DateTime.Now

                    };
                    db.Attendances.Add(newAtt);
                    db.SaveChanges();
                    RefreshData();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid ID!");
            }
            
            
        }
        private void RefreshData()
        {
            //idr onn ana chahye
            var query = from att in db.Attendances join memb in db.Members on att.MemberID equals memb.Id
                        select new
                        {
                           //idr aur attributes ain gy
                            
                            Member_ID = att.MemberID,
                            Name = memb.Name,
                            Package = memb.Package,
                            DateTimeEntry = att.DOE

                        };
           
            this.recentAttendance.ItemsSource = query.ToList();
        }

        private void viewAttendance_Click(object sender, RoutedEventArgs e)
        {
            string date;
            try
            {
                date = this.attDate.SelectedDate.Value.ToShortDateString();
            }
            catch (Exception)
            {
                date = DateTime.Now.ToShortDateString();
            }
            try { 
                //var query = db.Attendances.Where(a => a.DOE.Value.Date.ToShortDateString().Equals(date));
            List<Attendance> att = db.Attendances.ToList().Where(a => a.DOE.Value.Date.ToShortDateString().Equals(date)).ToList();
            var query = from a in att
                        join memb in db.Members on a.MemberID equals memb.Id
                        select new
                        {
                            //idr aur attributes ain gy

                            Member_ID = a.MemberID,
                            Name = memb.Name,
                            Package = memb.Package,
                            DateTimeEntry = a.DOE

                        };

            //this.recentAttendance.ItemsSource = query.ToList().OrderBy(a => a.Member_ID);
            Fees fw = new Fees();
            fw.feeDataGrid.ItemsSource = query.ToList().OrderBy(a => a.Member_ID);
            fw.Show();
            fw.Title = date + " Fee Records";
                //int cou = db.Attendances.ToList().Where(a => a.DOE.Value.Date.ToShortDateString().Equals(date)).ToList().Count();
                //MessageBox.Show(cou.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid ID!");
            }
        }

        private void memberId_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.Key == Key.Return)
            {
                addAttBtn_Click(sender, new RoutedEventArgs());
            }
        }

        private void viewAttBtn_Click(object sender, RoutedEventArgs e)
        {
            try { 
            int membId = int.Parse(this.memberIdSearch.Text);

            var query = from a in db.Attendances
                        where a.MemberID == membId
                        select new
                        {
                            //idr aur attributes ain gy

                            Member_ID = a.MemberID,
                            DateTimeEntry = a.DOE

                        };

            Fees fw = new Fees();
            fw.feeDataGrid.ItemsSource = query.ToList().OrderBy(a => a.Member_ID);
            fw.Show();
            fw.Title = this.memberIdSearch.Text + "- Fee Records";
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid ID!");
            }
        }
        private void PreviewText(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
