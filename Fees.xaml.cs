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
    /// Interaction logic for Fees.xaml
    /// </summary>
    public partial class Fees : Window
    {
        FitnessFlexDB db = new FitnessFlexDB();
        public Fees()
        {
            InitializeComponent();
            var query = from m in db.Members
                        join f in db.Fees on m.Id equals f.MemberID
                        select new
                        {
                           Receipt_ID= f.Id,
                           Name =  m.Name,
                           Phone =  m.Contact,
                           Package = m.Package,
                           Paid_Date =  f.PaidDate,
                           Amount = f.ToBePaid,
                           Paid =  f.Paid,
                           Balance = f.FeeBalance
                        };
            this.feeDataGrid.ItemsSource = query.ToList();
        }

    }
}
