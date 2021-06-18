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
using System.Xml;
using System.Text.RegularExpressions;

namespace FitnessFlex
{
    /// <summary>
    /// Interaction logic for MemberAU.xaml
    /// </summary>
    public partial class MemberAU : MetroWindow
    {
        FitnessFlexDB db = new FitnessFlexDB();
        int memId;
        public Member newMember;
        public Fee fee;
        public MemberAU(bool update, Member m)
        {

            InitializeComponent();
            newMember = m;
            //this.ReceiptGen.IsEnabled = false;
            if (CustomSettings.LoadFile() && !update)
            {
                this.membership.ItemsSource = CustomSettings.GetPackages();
                this.feePlan.ItemsSource = CustomSettings.GetFeePlans();
                this.admissionFee.Text = CustomSettings.GetAdmissionFee();
            }
            else
            {
                MessageBox.Show("Settings File Not Found!");
            }


            if (update)
            {
                this.Save.Title = "Update";

                //this.feeSummaryGrid.Visibility = Visibility.Hidden;
                //this.feeSummaryText.Visibility = Visibility.Hidden;
                this.memberId.Text = newMember.Id.ToString();
                this.memberName.Text = newMember.Name;
                this.ReceiptGen.IsEnabled = true;
                if (!newMember.Sex.Equals(1))
                {
                    this.gender.IsOn = false;
                }
                else
                {
                    this.gender.IsOn = true;
                }

                this.phone.Text = newMember.Contact;
                this.address.Text = newMember.Address;
                this.dob.SelectedDate = newMember.DOB.Value;
                this.doj.SelectedDate = newMember.DOJ.Value;

                Dictionary<string, string> items = CustomSettings.GetPackages();
                this.membership.ItemsSource = items;
                this.membership.SelectedItem = items.FirstOrDefault(t => t.Key == newMember.Package);


                //this.membership.SelectedValue = newMember.Package;
                /*this.feesDataGrid.ItemsSource = db.Fees.ToList<Fee>().Where(membId => membId.MemberID == this.newMember.Id).Select(fee=> new { 
                    Invoice_ID = fee.Id,
                    Paid_Date = fee.PaidDate.Value,
                    Fee_Plan = fee.FeePlan,
                    Monthly = fee.MonthlyFeeTotal,
                    Previous_Dues = fee.PrevDues,
                    Trainer =fee.PersonalTrainerFee,
                    Admission = fee.AdmissionFee,
                    Adjustment = fee.Adjustment,
                    To_Paid = fee.ToBePaid,
                    Net_Total = fee.NetTotal,
                    Paid = fee.Paid,
                    Balance = fee.FeeBalance
                });*/
                this.feesDataGrid.ItemsSource = db.Fees.ToList().Where(membId => membId.MemberID == this.newMember.Id);
            }

        }

        private void FeeSelect(object sender, MouseButtonEventArgs e)
        {

        }
        public async void AddMemberAsync()
        {
            if(string.IsNullOrEmpty(memberName.Text) || string.IsNullOrEmpty(membership.Text) || string.IsNullOrEmpty(phone.Text))
            {
                MessageBox.Show("Enter the Required Details!");
            }
            else { 
            newMember = new Member()
            {
                //  Id = int.Parse(this.memberId.Text),
                Name = this.memberName.Text,
                Sex = Member.SexConverter(this.gender.IsOn),
                Package = this.membership.Text,
                Contact = this.phone.Text,
                DOB = this.dob.SelectedDate,
                DOJ = this.doj.SelectedDate,
                Address = this.address.Text,
            };
            db.Members.Add(newMember); //exception to be handled here for not added
            db.SaveChanges();
            memId = db.Members.ToList().Last().Id;
            await this.ShowMessageAsync("Member Added", "Member ID:" + memId.ToString());
            this.memberId.Text = memId.ToString();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (((Tile)sender).Title.Equals("Update"))
            {
                SaveAll(sender, null);
                this.ReceiptGen.IsEnabled = true;
            }
            else
            {
                AddMemberAsync();
                if (!AddMemberFee(memId))
                {
                    MessageBox.Show("Fees Not Added");
                    this.ReceiptGen.IsEnabled = false;
                }
            }
        }
        private bool AddMemberFee(int memId)
        {
            try { 
            fee = new Fee()
            {
                //Id = int.Parse(receiptNo.Text),
                PaidDate = paidDate.SelectedDate.Value.Date,
                FeePlan = feePlan.Text,
                From = feeFrom.SelectedDate.Value.Date,
                To = feeTo.SelectedDate.Value.Date,
                Mon = int.Parse(noOfMonths.Text),
                MonthlyFeeTotal = int.Parse(monthlyFeeTotal.Text),
                PrevDues = int.Parse(previousDues.Text),
                PersonalTrainerFee = int.Parse(personalTrainer.Text),
                AdmissionFee = int.Parse(admissionFee.Text),
                NetTotal = int.Parse(netTotal.Text),
                Adjustment = int.Parse(adjustment.Text),
                ToBePaid = int.Parse(totalFeeToPaid.Text),
                Paid = int.Parse(paidAmount.Text),
                FeeBalance = int.Parse(feeBalance.Text),
                MemberID = memId

            };
            db.Fees.Add(fee);
            db.SaveChanges();
            return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Fee Details Completely!");
            }
            return false;

        }
        private void PreviewText(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Receipt(object sender, RoutedEventArgs e)
        {
            Window newInvoice = new Invoice(newMember, fee);
            newInvoice.Show();
        }

        private void EditFee(object sender, RoutedEventArgs e)
        {


            Fee selectedRow = (Fee)this.feesDataGrid.SelectedItem;
            fee = selectedRow;
            this.receiptNo.Text = selectedRow.Id.ToString();
            this.paidDate.SelectedDate = selectedRow.PaidDate.Value;

            Dictionary<string, string> feeplans = CustomSettings.GetFeePlans();
            this.feePlan.ItemsSource = feeplans;

            this.feePlan.SelectedItem = feeplans.FirstOrDefault(t => t.Key == selectedRow.FeePlan);

            this.feeFrom.SelectedDate = selectedRow.From;
            this.feeTo.SelectedDate = selectedRow.To;
            this.noOfMonths.Text = selectedRow.Mon.ToString();
            this.monthlyFeeTotal.Text = selectedRow.MonthlyFeeTotal.ToString();
            this.previousDues.Text = selectedRow.PrevDues.ToString();
            this.personalTrainer.Text = selectedRow.PrevDues.ToString();
            this.admissionFee.Text = selectedRow.AdmissionFee.ToString();
            this.netTotal.Text = selectedRow.NetTotal.ToString();
            this.adjustment.Text = selectedRow.Adjustment.ToString();
            this.totalFeeToPaid.Text = selectedRow.ToBePaid.ToString();
            this.paidAmount.Text = selectedRow.Paid.ToString();
            this.feeBalance.Text = selectedRow.FeeBalance.ToString();
        }

        private void SaveEditMember(object sender, RoutedEventArgs e)
        {
            newMember.Name = this.memberName.Text;
            newMember.Sex = Member.SexConverter(this.gender.IsOn);
            newMember.Package = this.membership.Text;
            newMember.Contact = this.phone.Text;
            newMember.DOB = this.dob.SelectedDate;
            newMember.DOJ = this.doj.SelectedDate;
            newMember.Address = this.address.Text;
//            db.SaveChanges();

        }
        private void SaveFee(object sender, RoutedEventArgs e)
        {


            //Id = int.Parse(receiptNo.Text),
            fee.PaidDate = paidDate.SelectedDate.Value.Date;
            fee.FeePlan = feePlan.Text;
            fee.From = feeFrom.SelectedDate.Value.Date;
            fee.To = feeTo.SelectedDate.Value.Date;
            fee.Mon = int.Parse(noOfMonths.Text);
            fee.MonthlyFeeTotal = int.Parse(monthlyFeeTotal.Text);
            fee.PrevDues = int.Parse(previousDues.Text);
            fee.PersonalTrainerFee = int.Parse(personalTrainer.Text);
            fee.AdmissionFee = int.Parse(admissionFee.Text);
            fee.NetTotal = int.Parse(netTotal.Text);
            fee.Adjustment = int.Parse(adjustment.Text);
            fee.ToBePaid = int.Parse(totalFeeToPaid.Text);
            fee.Paid = int.Parse(paidAmount.Text);
            fee.FeeBalance = int.Parse(feeBalance.Text);
            //fee.MemberID = memId;
            db.SaveChanges();
        }
        private void SaveAll(object sender,RoutedEventArgs e)
        {
            this.SaveEditMember(sender, new RoutedEventArgs());
            this.SaveFee(sender, new RoutedEventArgs());

        }

    }
}
 