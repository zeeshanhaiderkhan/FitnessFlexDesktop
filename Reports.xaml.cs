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
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        FitnessFlexDB db = new FitnessFlexDB();
        public Reports()
        {
            InitializeComponent();

        }
        string getGender(int i)
        {
            if (i == 1) return "Male";
            return "Female";
        }
        private void getReports_Click(object sender, RoutedEventArgs e)
        {
            try { 
            DateTime stDate = (DateTime)startDate.SelectedDate;
            DateTime enDate = (DateTime)endDate.SelectedDate;
            bool fee = (bool)feeRad.IsChecked;
            bool members = (bool)membersRad.IsChecked;
                if (members)
                {
                    //var query = db.Members.ToList().Where( m => m.DOE.Value.Date.)
                    var query = from m in db.Members
                                where m.DOJ.Value >= stDate && m.DOJ.Value <= enDate
                                select new
                                {
                                    ID = m.Id,
                                    Name = m.Name,
                                    Gender = m.Sex,
                                    Package = m.Package,
                                    Address = m.Address,
                                    DOB = m.DOB,
                                    DOJ = m.DOJ,
                                    DOE = m.DOE
                                };
                    Fees memWin = new Fees();
                    memWin.feeDataGrid.ItemsSource = query.ToList();
                    memWin.Title = stDate.ToShortDateString() + " - " + enDate.ToShortDateString()  +" - Members Data";
                    memWin.Show();

                }
                if (fee)
                {
                    var query = from f in db.Fees
                                where f.PaidDate.Value >= stDate && f.PaidDate.Value <= enDate select f;
                    Fees memWin = new Fees();
                    memWin.feeDataGrid.ItemsSource = query.ToList();
                    memWin.Title = stDate.ToShortDateString()+" - "+enDate.ToShortDateString()  + " - Fees Data";
                    memWin.Show();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Dates!");
            }

            // MessageBox.Show(sDate + " " + eDate + " " + fee.ToString() + " " + members.ToString());
            
        }
    }
}
